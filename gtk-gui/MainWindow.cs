
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.VBox vbox_main;

	private global::Gtk.HBox hbox_io;

	private global::Gtk.VBox vbox_input;

	private global::Gtk.FileChooserButton file_load;

	private global::Gtk.Image img_load;

	private global::Gtk.Label l_load;

	private global::Gtk.HBox hbox_input_params;

	private global::Gtk.Button b_load;

	private global::Gtk.SpinButton num_xoffset;

	private global::Gtk.SpinButton num_yoffset;

	private global::Gtk.VBox vbox_output;

	private global::Gtk.FileChooserButton file_export;

	private global::Gtk.Image img_encoded;

	private global::Gtk.Label l_export;

	private global::Gtk.HBox hbox_output_export;

	private global::Gtk.Button b_preview;

	private global::Gtk.Button b_export;

	private global::Gtk.Entry password_input;

	private global::Gtk.ScrolledWindow GtkScrolledWindow;

	private global::Gtk.TextView text_input;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("Secret Messages");
		this.Icon = global::Stetic.IconLoader.LoadIcon(this, "gtk-select-color", global::Gtk.IconSize.Menu);
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		this.BorderWidth = ((uint)(6));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox_main = new global::Gtk.VBox();
		this.vbox_main.Name = "vbox_main";
		this.vbox_main.Spacing = 6;
		// Container child vbox_main.Gtk.Box+BoxChild
		this.hbox_io = new global::Gtk.HBox();
		this.hbox_io.Name = "hbox_io";
		this.hbox_io.Spacing = 6;
		// Container child hbox_io.Gtk.Box+BoxChild
		this.vbox_input = new global::Gtk.VBox();
		this.vbox_input.Name = "vbox_input";
		this.vbox_input.Spacing = 6;
		// Container child vbox_input.Gtk.Box+BoxChild
		this.file_load = new global::Gtk.FileChooserButton(global::Mono.Unix.Catalog.GetString("Load image..."), ((global::Gtk.FileChooserAction)(0)));
		this.file_load.TooltipMarkup = "Input file";
		this.file_load.Name = "file_load";
		this.file_load.LocalOnly = false;
		this.file_load.ShowHidden = true;
		this.vbox_input.Add(this.file_load);
		global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox_input[this.file_load]));
		w1.Position = 0;
		w1.Expand = false;
		w1.Fill = false;
		// Container child vbox_input.Gtk.Box+BoxChild
		this.img_load = new global::Gtk.Image();
		this.img_load.WidthRequest = 150;
		this.img_load.HeightRequest = 150;
		this.img_load.Name = "img_load";
		this.vbox_input.Add(this.img_load);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox_input[this.img_load]));
		w2.Position = 1;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox_input.Gtk.Box+BoxChild
		this.l_load = new global::Gtk.Label();
		this.l_load.TooltipMarkup = "Modification date of the input file";
		this.l_load.Name = "l_load";
		this.l_load.LabelProp = global::Mono.Unix.Catalog.GetString("(date)");
		this.vbox_input.Add(this.l_load);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox_input[this.l_load]));
		w3.Position = 2;
		w3.Expand = false;
		w3.Fill = false;
		// Container child vbox_input.Gtk.Box+BoxChild
		this.hbox_input_params = new global::Gtk.HBox();
		this.hbox_input_params.Name = "hbox_input_params";
		this.hbox_input_params.Spacing = 6;
		// Container child hbox_input_params.Gtk.Box+BoxChild
		this.b_load = new global::Gtk.Button();
		this.b_load.TooltipMarkup = "Reloads the input image";
		this.b_load.CanFocus = true;
		this.b_load.Name = "b_load";
		this.b_load.UseUnderline = true;
		this.b_load.Label = global::Mono.Unix.Catalog.GetString(" ⭯ ");
		this.hbox_input_params.Add(this.b_load);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox_input_params[this.b_load]));
		w4.Position = 0;
		w4.Expand = false;
		w4.Fill = false;
		// Container child hbox_input_params.Gtk.Box+BoxChild
		this.num_xoffset = new global::Gtk.SpinButton(0D, 100D, 1D);
		this.num_xoffset.TooltipMarkup = "X Offset (for Input and Output)";
		this.num_xoffset.CanFocus = true;
		this.num_xoffset.Name = "num_xoffset";
		this.num_xoffset.Adjustment.PageIncrement = 10D;
		this.num_xoffset.ClimbRate = 1D;
		this.num_xoffset.Numeric = true;
		this.hbox_input_params.Add(this.num_xoffset);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox_input_params[this.num_xoffset]));
		w5.Position = 1;
		// Container child hbox_input_params.Gtk.Box+BoxChild
		this.num_yoffset = new global::Gtk.SpinButton(0D, 100D, 1D);
		this.num_yoffset.TooltipMarkup = "Y Offset (for Input and Output)";
		this.num_yoffset.CanFocus = true;
		this.num_yoffset.Name = "num_yoffset";
		this.num_yoffset.Adjustment.PageIncrement = 10D;
		this.num_yoffset.ClimbRate = 1D;
		this.num_yoffset.Numeric = true;
		this.hbox_input_params.Add(this.num_yoffset);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox_input_params[this.num_yoffset]));
		w6.Position = 2;
		this.vbox_input.Add(this.hbox_input_params);
		global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox_input[this.hbox_input_params]));
		w7.Position = 3;
		w7.Expand = false;
		w7.Fill = false;
		this.hbox_io.Add(this.vbox_input);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox_io[this.vbox_input]));
		w8.Position = 0;
		// Container child hbox_io.Gtk.Box+BoxChild
		this.vbox_output = new global::Gtk.VBox();
		this.vbox_output.Name = "vbox_output";
		this.vbox_output.Spacing = 6;
		// Container child vbox_output.Gtk.Box+BoxChild
		this.file_export = new global::Gtk.FileChooserButton(global::Mono.Unix.Catalog.GetString("Save as..."), ((global::Gtk.FileChooserAction)(0)));
		this.file_export.TooltipMarkup = "Output file";
		this.file_export.Name = "file_export";
		this.file_export.LocalOnly = false;
		this.file_export.DoOverwriteConfirmation = true;
		this.vbox_output.Add(this.file_export);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox_output[this.file_export]));
		w9.Position = 0;
		w9.Expand = false;
		w9.Fill = false;
		// Container child vbox_output.Gtk.Box+BoxChild
		this.img_encoded = new global::Gtk.Image();
		this.img_encoded.WidthRequest = 150;
		this.img_encoded.HeightRequest = 150;
		this.img_encoded.Name = "img_encoded";
		this.vbox_output.Add(this.img_encoded);
		global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox_output[this.img_encoded]));
		w10.Position = 1;
		w10.Expand = false;
		w10.Fill = false;
		// Container child vbox_output.Gtk.Box+BoxChild
		this.l_export = new global::Gtk.Label();
		this.l_export.TooltipMarkup = "Modification date of the output file";
		this.l_export.Name = "l_export";
		this.l_export.LabelProp = global::Mono.Unix.Catalog.GetString("(date)");
		this.vbox_output.Add(this.l_export);
		global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox_output[this.l_export]));
		w11.Position = 2;
		w11.Expand = false;
		w11.Fill = false;
		// Container child vbox_output.Gtk.Box+BoxChild
		this.hbox_output_export = new global::Gtk.HBox();
		this.hbox_output_export.Name = "hbox_output_export";
		this.hbox_output_export.Spacing = 6;
		// Container child hbox_output_export.Gtk.Box+BoxChild
		this.b_preview = new global::Gtk.Button();
		this.b_preview.TooltipMarkup = "Preview capacity of output image";
		this.b_preview.CanFocus = true;
		this.b_preview.Name = "b_preview";
		this.b_preview.UseUnderline = true;
		this.b_preview.Label = global::Mono.Unix.Catalog.GetString("Preview");
		this.hbox_output_export.Add(this.b_preview);
		global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox_output_export[this.b_preview]));
		w12.Position = 0;
		// Container child hbox_output_export.Gtk.Box+BoxChild
		this.b_export = new global::Gtk.Button();
		this.b_export.TooltipMarkup = "Export the image using the password and text";
		this.b_export.CanFocus = true;
		this.b_export.Name = "b_export";
		this.b_export.UseUnderline = true;
		this.b_export.Label = global::Mono.Unix.Catalog.GetString("Export");
		this.hbox_output_export.Add(this.b_export);
		global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox_output_export[this.b_export]));
		w13.Position = 1;
		this.vbox_output.Add(this.hbox_output_export);
		global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox_output[this.hbox_output_export]));
		w14.Position = 3;
		w14.Expand = false;
		w14.Fill = false;
		this.hbox_io.Add(this.vbox_output);
		global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox_io[this.vbox_output]));
		w15.Position = 1;
		this.vbox_main.Add(this.hbox_io);
		global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox_main[this.hbox_io]));
		w16.Position = 0;
		w16.Expand = false;
		w16.Fill = false;
		// Container child vbox_main.Gtk.Box+BoxChild
		this.password_input = new global::Gtk.Entry();
		this.password_input.TooltipMarkup = "Password for the encryption (empty = none)";
		this.password_input.HeightRequest = 30;
		this.password_input.CanDefault = true;
		this.password_input.CanFocus = true;
		this.password_input.Name = "password_input";
		this.password_input.IsEditable = true;
		this.password_input.InvisibleChar = '•';
		this.vbox_main.Add(this.password_input);
		global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox_main[this.password_input]));
		w17.Position = 1;
		w17.Expand = false;
		w17.Fill = false;
		// Container child vbox_main.Gtk.Box+BoxChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.text_input = new global::Gtk.TextView();
		this.text_input.HeightRequest = 100;
		this.text_input.CanFocus = true;
		this.text_input.Name = "text_input";
		this.text_input.WrapMode = ((global::Gtk.WrapMode)(3));
		this.GtkScrolledWindow.Add(this.text_input);
		this.vbox_main.Add(this.GtkScrolledWindow);
		global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.vbox_main[this.GtkScrolledWindow]));
		w19.Position = 2;
		this.Add(this.vbox_main);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.DefaultWidth = 319;
		this.DefaultHeight = 417;
		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
		this.file_load.SelectionChanged += new global::System.EventHandler(this.LoadImage);
		this.b_load.Clicked += new global::System.EventHandler(this.LoadImage);
		this.file_export.SelectionChanged += new global::System.EventHandler(this.SelectDestination);
		this.b_preview.Clicked += new global::System.EventHandler(this.PreviewImage);
		this.b_export.Clicked += new global::System.EventHandler(this.ExportImage);
	}
}
