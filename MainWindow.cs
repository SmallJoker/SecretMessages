/*
Copyright (C) 2019 Krock/SmallJoker <mk939@ymail.com>

This library is free software; you can redistribute it and/or
modify it under the terms of the GNU Lesser General Public
License as published by the Free Software Foundation; either
version 3.0 of the License, or (at your option) any later version.

This library is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public
License along with this library.
*/

using System;
using System.Drawing;
using System.Drawing.Imaging;
using Gtk;

namespace VersteckteInfo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();
            MainWindow win = new MainWindow();
            win.Show();
            Application.Run();
        }
    }
}

public partial class MainWindow : Gtk.Window
{
	Bitmap loaded_bmp = null;
	System.Text.Encoding enc = System.Text.Encoding.UTF8;
    System.Security.Cryptography.SHA256 hash = System.Security.Cryptography.SHA256.Create();
	ImageFormat format = ImageFormat.Png;

	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();
		//file_export.ImagePosition = PositionType.Right;
		//Settings.ButtonImages = true;
        file_load.SetCurrentFolder("/");
		file_export.SetCurrentFolder("/");

		var font = new Pango.FontDescription();
		font.Family = "monospace";
		font.Size = (int)(9 * Pango.Scale.PangoScale);
		text_input.ModifyFont(font);
	}

	void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}

	// Helper function to show any error message
	void ShowErrorDialog(string text)
	{
		MessageDialog md = new MessageDialog(this, 
            DialogFlags.DestroyWithParent, MessageType.Error, 
            ButtonsType.Ok, text);
        md.Run();
        md.Destroy();
	}

	// Generate new hash value based on the previous hash plus the password contents
    void GetNextHash(ref byte[] hash_bytes)
    {
		byte[] password = enc.GetBytes(password_input.Text);
		if (password.Length == 0)
			return;

		var ms = new System.IO.MemoryStream();
		ms.Write(hash_bytes, 0, hash_bytes.Length);
		ms.Write(password, 0, password.Length);
		ms.Position = 0;
		hash_bytes = hash.ComputeHash(ms);
		ms.Close();
	}

	// Callback: File export
	void SelectDestination(object sender, EventArgs e)
	{
		if (System.IO.File.Exists(file_export.Filename))
			return;

		if (loaded_bmp != null)
			ExportImage(sender, e);
		else
			System.IO.File.WriteAllBytes(file_export.Filename, new byte[0]);
	}

	// Callback: A file was selected in the input file selector
	void LoadImage(object sender, EventArgs e)
	{
		if (!System.IO.File.Exists(file_load.Filename)) {
			ShowErrorDialog("Cannot load the image: File not found.");
			return;
		}

		// Hacky check whether it's actually an image
		Bitmap input = loaded_bmp;
		try {
			input = new Bitmap(file_load.Filename);
		} catch (Exception ex) {
			ShowErrorDialog("Unknown/Unsupported image format. Please select a losslessly saved image.\n"
				+ ex.Message);
			file_load.SelectFilename(null);
			return;
		}

		DateTime d = System.IO.File.GetLastWriteTime(file_load.Filename);
		l_load.LabelProp = d.ToString();
		
		// Decode stuff
		byte counter = 0;
		int character = 0;
		var ms = new System.IO.MemoryStream();
		byte[] hash_bytes = new byte[2];
		GetNextHash(ref hash_bytes);

		for (int y = num_yoffset.ValueAsInt; y < input.Height; ++y)
			for (int x = num_xoffset.ValueAsInt; x < input.Width; ++x) {
				Color c = input.GetPixel(x, y);
				if (c.A == 0)
					continue;

                int pr, pg, pb;

				pr = c.R & 1;
				pg = c.G & 1;
				pb = c.B & 1;
				if ((pr ^ pg ^ (hash_bytes[1] & 1)) != pb)
					goto EXIT_LOOP; // Sanity check failed

				character >>= 2;
				character |= (pg << 7) | (pr << 6);

				//character |= (byte)(((c.R ^ c.G ^ c.B) & 1) << counter);

				counter += 2;
				if (counter == 8) {
                    character ^= hash_bytes[0];
					//ShowErrorDialog("hash: " + hash_bytes[0] + "\nchar: " + character);
                    GetNextHash(ref hash_bytes);

					if (character == 0)
						goto EXIT_LOOP;

					ms.WriteByte((byte)character);
					character = 0;
					counter = 0;
				}
		}
EXIT_LOOP:
		loaded_bmp = input;
		input = null;
		ms.Position = 0;
		text_input.Buffer.Text = enc.GetString(ms.ToArray());
		img_load.Pixbuf = new Gdk.Pixbuf(file_load.Filename)
			;//.ScaleSimple(img_load.Allocation.Width, img_load.Allocation.Width, Gdk.InterpType.Hyper);
	}

	void PreviewImage(object sender, EventArgs e)
	{
		if (loaded_bmp == null) {
			ShowErrorDialog("Cannot preview: No file is loaded.");
			return;
		}
		
		var ms = new System.IO.MemoryStream();
		Bitmap bmp_written = new Bitmap(loaded_bmp);

		// Read text
		byte[] data = enc.GetBytes(text_input.Buffer.Text);
		ms.Write(data, 0, data.Length);
		ms.WriteByte(0);
		data = null;
		ms.Position = 0;
		
		// Encode stuff
		byte counter = 0;
		int character = ms.ReadByte();

		byte[] hash_bytes = new byte[2];
		GetNextHash(ref hash_bytes);
		character ^= hash_bytes[0];

		for (int y = num_yoffset.ValueAsInt; y < loaded_bmp.Height; ++y)
			for (int x = num_xoffset.ValueAsInt; x < loaded_bmp.Width; ++x) {
				Color c = loaded_bmp.GetPixel(x, y);
				if (c.A == 0)
					continue;

				int pr, pg, pb;

				pr = (c.R & 0xFE) | (character & 1);
				character >>= 1;
				pg = (c.G & 0xFE) | (character & 1);
                character >>= 1;
				pb = (c.B & 0xFE) | ((pr ^ pg ^ hash_bytes[1]) & 1);

				loaded_bmp.SetPixel(x, y, Color.FromArgb(c.A, pr, pg, pb));
				// Mark image as written
				bmp_written.SetPixel(x, y, Color.FromArgb(c.A, c.R, c.B, 255 - c.G));

				counter += 2;
				if (counter == 8) {
					int newchr = ms.ReadByte();
					if (newchr == -1) // End of file
						goto EXIT_LOOP;

					GetNextHash(ref hash_bytes);
                    //ShowErrorDialog("hash: " + hash_bytes[0] + "\nchar: " + newchr);
					character = newchr ^ hash_bytes[0];
					counter = 0;
				}
		}

		if (counter != 0)
			ShowErrorDialog("Cannot write entire message: "
				+ (ms.Length - ms.Position) + " leftover bytes.");

EXIT_LOOP:
		ms.Close();
		ms = new System.IO.MemoryStream();
		bmp_written.Save(ms, format);
		ms.Position = 0;
		img_encoded.Pixbuf = new Gdk.Pixbuf(ms)
			;//.ScaleSimple(img_encoded.Allocation.Width, img_encoded.Allocation.Width, Gdk.InterpType.Hyper);
	}

	void ExportImage(object sender, EventArgs e)
	{
		if (loaded_bmp == null || file_export.Filename == null) {
			ShowErrorDialog("Cannot export: No image loaded or output path given.");
			return;
		}
		string old_label = b_export.Label;
		b_export.Label = "(saving)";
		PreviewImage(sender, e);
		try {
			loaded_bmp.Save(file_export.Filename, format);
			DateTime d = System.IO.File.GetLastWriteTime(file_export.Filename);
			l_export.LabelProp = d.ToString();
		} catch (Exception ex) {
			ShowErrorDialog("Saving failed.\n" + ex.Message);
		}
		b_export.Label = old_label;
	}
}
