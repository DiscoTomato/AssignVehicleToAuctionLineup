using System.Windows.Forms;

namespace AssignLaneLot_WinFormsUI
{
    partial class AssignLaneLot : Form // CustomControls.BaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("150000 - JM1NDAC74G0106681 - 2020 MERCEDES-BENZ PROMASTER CARGO VAN");
            this.label3 = new System.Windows.Forms.Label();
            this.FullScreenPanel = new System.Windows.Forms.Panel();
            this.SellerInfoLabel = new System.Windows.Forms.Label();
            this.VehicleDescriptionLabel = new System.Windows.Forms.Label();
            this.SellerLineup = new System.Windows.Forms.ListView();
            this.AssignedReservations = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.OpenReservationsList = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton26 = new System.Windows.Forms.RadioButton();
            this.radioButton25 = new System.Windows.Forms.RadioButton();
            this.radioButton18 = new System.Windows.Forms.RadioButton();
            this.radioButton19 = new System.Windows.Forms.RadioButton();
            this.radioButton20 = new System.Windows.Forms.RadioButton();
            this.radioButton21 = new System.Windows.Forms.RadioButton();
            this.radioButton22 = new System.Windows.Forms.RadioButton();
            this.radioButton24 = new System.Windows.Forms.RadioButton();
            this.radioButton17 = new System.Windows.Forms.RadioButton();
            this.radioButton16 = new System.Windows.Forms.RadioButton();
            this.radioButton15 = new System.Windows.Forms.RadioButton();
            this.radioButton14 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton23 = new System.Windows.Forms.RadioButton();
            this.ReservationNotAvailable = new System.Windows.Forms.Label();
            this.NoOpenReservationsMessage = new System.Windows.Forms.Label();
            this.SellerInfo = new System.Windows.Forms.Label();
            this.VehicleDescription = new System.Windows.Forms.Label();
            this.SearchOpenReservations = new System.Windows.Forms.Button();
            this.SaleDate = new System.Windows.Forms.Label();
            this.ViewLineup = new System.Windows.Forms.Button();
            this.SaleDateLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ConfirmReservation = new System.Windows.Forms.Button();
            this.FullScreenPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.OpenReservationsList.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 15.75F);
            this.label3.Location = new System.Drawing.Point(486, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(291, 32);
            this.label3.TabIndex = 27;
            this.label3.Text = "Request Reservation";
            // 
            // FullScreenPanel
            // 
            this.FullScreenPanel.Controls.Add(this.SellerInfoLabel);
            this.FullScreenPanel.Controls.Add(this.VehicleDescriptionLabel);
            this.FullScreenPanel.Controls.Add(this.SellerLineup);
            this.FullScreenPanel.Controls.Add(this.panel2);
            this.FullScreenPanel.Controls.Add(this.ReservationNotAvailable);
            this.FullScreenPanel.Controls.Add(this.NoOpenReservationsMessage);
            this.FullScreenPanel.Controls.Add(this.SellerInfo);
            this.FullScreenPanel.Controls.Add(this.VehicleDescription);
            this.FullScreenPanel.Controls.Add(this.label3);
            this.FullScreenPanel.Controls.Add(this.SearchOpenReservations);
            this.FullScreenPanel.Controls.Add(this.SaleDate);
            this.FullScreenPanel.Controls.Add(this.ViewLineup);
            this.FullScreenPanel.Controls.Add(this.SaleDateLabel);
            this.FullScreenPanel.Location = new System.Drawing.Point(0, 0);
            this.FullScreenPanel.Name = "FullScreenPanel";
            this.FullScreenPanel.Size = new System.Drawing.Size(1200, 616);
            this.FullScreenPanel.TabIndex = 28;
            this.FullScreenPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaintFullScreenPanel);
            // 
            // SellerInfoLabel
            // 
            this.SellerInfoLabel.AutoSize = true;
            this.SellerInfoLabel.Font = new System.Drawing.Font("Verdana", 12F);
            this.SellerInfoLabel.Location = new System.Drawing.Point(12, 297);
            this.SellerInfoLabel.Name = "SellerInfoLabel";
            this.SellerInfoLabel.Size = new System.Drawing.Size(80, 25);
            this.SellerInfoLabel.TabIndex = 42;
            this.SellerInfoLabel.Text = "Seller:";
            // 
            // VehicleDescriptionLabel
            // 
            this.VehicleDescriptionLabel.AutoSize = true;
            this.VehicleDescriptionLabel.Font = new System.Drawing.Font("Verdana", 12F);
            this.VehicleDescriptionLabel.Location = new System.Drawing.Point(12, 95);
            this.VehicleDescriptionLabel.Name = "VehicleDescriptionLabel";
            this.VehicleDescriptionLabel.Size = new System.Drawing.Size(93, 25);
            this.VehicleDescriptionLabel.TabIndex = 41;
            this.VehicleDescriptionLabel.Text = "Vehicle:";
            // 
            // SellerLineup
            // 
            this.SellerLineup.BackColor = System.Drawing.Color.DarkBlue;
            this.SellerLineup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SellerLineup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AssignedReservations});
            this.SellerLineup.Font = new System.Drawing.Font("Verdana", 12F);
            this.SellerLineup.ForeColor = System.Drawing.Color.White;
            this.SellerLineup.HideSelection = false;
            this.SellerLineup.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.SellerLineup.Location = new System.Drawing.Point(475, 95);
            this.SellerLineup.Name = "SellerLineup";
            this.SellerLineup.Size = new System.Drawing.Size(713, 509);
            this.SellerLineup.TabIndex = 40;
            this.SellerLineup.UseCompatibleStateImageBehavior = false;
            this.SellerLineup.View = System.Windows.Forms.View.Details;
            this.SellerLineup.Visible = false;
            // 
            // AssignedReservations
            // 
            this.AssignedReservations.Text = "Seller\'s Lineup";
            this.AssignedReservations.Width = 713;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.OpenReservationsList);
            this.panel2.Location = new System.Drawing.Point(242, 95);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(219, 509);
            this.panel2.TabIndex = 39;
            // 
            // OpenReservationsList
            // 
            this.OpenReservationsList.AutoSize = true;
            this.OpenReservationsList.Controls.Add(this.radioButton2);
            this.OpenReservationsList.Controls.Add(this.radioButton1);
            this.OpenReservationsList.Controls.Add(this.radioButton26);
            this.OpenReservationsList.Controls.Add(this.radioButton25);
            this.OpenReservationsList.Controls.Add(this.radioButton18);
            this.OpenReservationsList.Controls.Add(this.radioButton19);
            this.OpenReservationsList.Controls.Add(this.radioButton20);
            this.OpenReservationsList.Controls.Add(this.radioButton21);
            this.OpenReservationsList.Controls.Add(this.radioButton22);
            this.OpenReservationsList.Controls.Add(this.radioButton24);
            this.OpenReservationsList.Controls.Add(this.radioButton17);
            this.OpenReservationsList.Controls.Add(this.radioButton16);
            this.OpenReservationsList.Controls.Add(this.radioButton15);
            this.OpenReservationsList.Controls.Add(this.radioButton14);
            this.OpenReservationsList.Controls.Add(this.radioButton7);
            this.OpenReservationsList.Controls.Add(this.radioButton23);
            this.OpenReservationsList.Font = new System.Drawing.Font("Verdana", 12F);
            this.OpenReservationsList.ForeColor = System.Drawing.Color.White;
            this.OpenReservationsList.Location = new System.Drawing.Point(16, 2);
            this.OpenReservationsList.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.OpenReservationsList.Name = "OpenReservationsList";
            this.OpenReservationsList.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.OpenReservationsList.Size = new System.Drawing.Size(178, 603);
            this.OpenReservationsList.TabIndex = 13;
            this.OpenReservationsList.TabStop = false;
            this.OpenReservationsList.Text = "Open Reservations";
            this.OpenReservationsList.Visible = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Verdana", 12F);
            this.radioButton2.Location = new System.Drawing.Point(22, 539);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(0);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.radioButton2.Size = new System.Drawing.Size(118, 33);
            this.radioButton2.TabIndex = 40;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "15 0020";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Verdana", 12F);
            this.radioButton1.Location = new System.Drawing.Point(22, 505);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(0);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.radioButton1.Size = new System.Drawing.Size(118, 33);
            this.radioButton1.TabIndex = 39;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "15 0019";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton26
            // 
            this.radioButton26.AutoSize = true;
            this.radioButton26.Font = new System.Drawing.Font("Verdana", 12F);
            this.radioButton26.Location = new System.Drawing.Point(22, 471);
            this.radioButton26.Margin = new System.Windows.Forms.Padding(0);
            this.radioButton26.Name = "radioButton26";
            this.radioButton26.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.radioButton26.Size = new System.Drawing.Size(118, 33);
            this.radioButton26.TabIndex = 38;
            this.radioButton26.TabStop = true;
            this.radioButton26.Text = "15 0018";
            this.radioButton26.UseVisualStyleBackColor = true;
            // 
            // radioButton25
            // 
            this.radioButton25.AutoSize = true;
            this.radioButton25.Font = new System.Drawing.Font("Verdana", 12F);
            this.radioButton25.Location = new System.Drawing.Point(22, 436);
            this.radioButton25.Margin = new System.Windows.Forms.Padding(0);
            this.radioButton25.Name = "radioButton25";
            this.radioButton25.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.radioButton25.Size = new System.Drawing.Size(118, 33);
            this.radioButton25.TabIndex = 37;
            this.radioButton25.TabStop = true;
            this.radioButton25.Text = "15 0017";
            this.radioButton25.UseVisualStyleBackColor = true;
            // 
            // radioButton18
            // 
            this.radioButton18.AutoSize = true;
            this.radioButton18.Font = new System.Drawing.Font("Verdana", 12F);
            this.radioButton18.Location = new System.Drawing.Point(22, 402);
            this.radioButton18.Margin = new System.Windows.Forms.Padding(0);
            this.radioButton18.Name = "radioButton18";
            this.radioButton18.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.radioButton18.Size = new System.Drawing.Size(118, 33);
            this.radioButton18.TabIndex = 36;
            this.radioButton18.TabStop = true;
            this.radioButton18.Text = "15 0016";
            this.radioButton18.UseVisualStyleBackColor = true;
            // 
            // radioButton19
            // 
            this.radioButton19.AutoSize = true;
            this.radioButton19.Font = new System.Drawing.Font("Verdana", 12F);
            this.radioButton19.Location = new System.Drawing.Point(22, 368);
            this.radioButton19.Margin = new System.Windows.Forms.Padding(0);
            this.radioButton19.Name = "radioButton19";
            this.radioButton19.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.radioButton19.Size = new System.Drawing.Size(118, 33);
            this.radioButton19.TabIndex = 35;
            this.radioButton19.TabStop = true;
            this.radioButton19.Text = "15 0015";
            this.radioButton19.UseVisualStyleBackColor = true;
            // 
            // radioButton20
            // 
            this.radioButton20.AutoSize = true;
            this.radioButton20.Font = new System.Drawing.Font("Verdana", 12F);
            this.radioButton20.Location = new System.Drawing.Point(22, 334);
            this.radioButton20.Margin = new System.Windows.Forms.Padding(0);
            this.radioButton20.Name = "radioButton20";
            this.radioButton20.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.radioButton20.Size = new System.Drawing.Size(118, 33);
            this.radioButton20.TabIndex = 34;
            this.radioButton20.TabStop = true;
            this.radioButton20.Text = "15 0014";
            this.radioButton20.UseVisualStyleBackColor = true;
            // 
            // radioButton21
            // 
            this.radioButton21.AutoSize = true;
            this.radioButton21.Font = new System.Drawing.Font("Verdana", 12F);
            this.radioButton21.Location = new System.Drawing.Point(22, 300);
            this.radioButton21.Margin = new System.Windows.Forms.Padding(0);
            this.radioButton21.Name = "radioButton21";
            this.radioButton21.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.radioButton21.Size = new System.Drawing.Size(118, 33);
            this.radioButton21.TabIndex = 33;
            this.radioButton21.TabStop = true;
            this.radioButton21.Text = "15 0013";
            this.radioButton21.UseVisualStyleBackColor = true;
            // 
            // radioButton22
            // 
            this.radioButton22.AutoSize = true;
            this.radioButton22.Font = new System.Drawing.Font("Verdana", 12F);
            this.radioButton22.Location = new System.Drawing.Point(22, 266);
            this.radioButton22.Margin = new System.Windows.Forms.Padding(0);
            this.radioButton22.Name = "radioButton22";
            this.radioButton22.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.radioButton22.Size = new System.Drawing.Size(118, 33);
            this.radioButton22.TabIndex = 32;
            this.radioButton22.TabStop = true;
            this.radioButton22.Text = "15 0012";
            this.radioButton22.UseVisualStyleBackColor = true;
            // 
            // radioButton24
            // 
            this.radioButton24.AutoSize = true;
            this.radioButton24.Font = new System.Drawing.Font("Verdana", 12F);
            this.radioButton24.Location = new System.Drawing.Point(22, 232);
            this.radioButton24.Margin = new System.Windows.Forms.Padding(0);
            this.radioButton24.Name = "radioButton24";
            this.radioButton24.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.radioButton24.Size = new System.Drawing.Size(118, 33);
            this.radioButton24.TabIndex = 31;
            this.radioButton24.TabStop = true;
            this.radioButton24.Text = "15 0011";
            this.radioButton24.UseVisualStyleBackColor = true;
            // 
            // radioButton17
            // 
            this.radioButton17.AutoSize = true;
            this.radioButton17.Font = new System.Drawing.Font("Verdana", 12F);
            this.radioButton17.Location = new System.Drawing.Point(22, 198);
            this.radioButton17.Margin = new System.Windows.Forms.Padding(0);
            this.radioButton17.Name = "radioButton17";
            this.radioButton17.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.radioButton17.Size = new System.Drawing.Size(118, 33);
            this.radioButton17.TabIndex = 30;
            this.radioButton17.TabStop = true;
            this.radioButton17.Text = "15 0010";
            this.radioButton17.UseVisualStyleBackColor = true;
            // 
            // radioButton16
            // 
            this.radioButton16.AutoSize = true;
            this.radioButton16.Font = new System.Drawing.Font("Verdana", 12F);
            this.radioButton16.Location = new System.Drawing.Point(22, 164);
            this.radioButton16.Margin = new System.Windows.Forms.Padding(0);
            this.radioButton16.Name = "radioButton16";
            this.radioButton16.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.radioButton16.Size = new System.Drawing.Size(118, 33);
            this.radioButton16.TabIndex = 29;
            this.radioButton16.TabStop = true;
            this.radioButton16.Text = "15 0009";
            this.radioButton16.UseVisualStyleBackColor = true;
            // 
            // radioButton15
            // 
            this.radioButton15.AutoSize = true;
            this.radioButton15.Font = new System.Drawing.Font("Verdana", 12F);
            this.radioButton15.Location = new System.Drawing.Point(22, 130);
            this.radioButton15.Margin = new System.Windows.Forms.Padding(0);
            this.radioButton15.Name = "radioButton15";
            this.radioButton15.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.radioButton15.Size = new System.Drawing.Size(118, 33);
            this.radioButton15.TabIndex = 28;
            this.radioButton15.TabStop = true;
            this.radioButton15.Text = "15 0008";
            this.radioButton15.UseVisualStyleBackColor = true;
            // 
            // radioButton14
            // 
            this.radioButton14.AutoSize = true;
            this.radioButton14.Font = new System.Drawing.Font("Verdana", 12F);
            this.radioButton14.Location = new System.Drawing.Point(22, 96);
            this.radioButton14.Margin = new System.Windows.Forms.Padding(0);
            this.radioButton14.Name = "radioButton14";
            this.radioButton14.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.radioButton14.Size = new System.Drawing.Size(118, 33);
            this.radioButton14.TabIndex = 27;
            this.radioButton14.TabStop = true;
            this.radioButton14.Text = "15 0007";
            this.radioButton14.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Font = new System.Drawing.Font("Verdana", 12F);
            this.radioButton7.Location = new System.Drawing.Point(22, 62);
            this.radioButton7.Margin = new System.Windows.Forms.Padding(0);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.radioButton7.Size = new System.Drawing.Size(118, 33);
            this.radioButton7.TabIndex = 26;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "15 0006";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton23
            // 
            this.radioButton23.AutoSize = true;
            this.radioButton23.Font = new System.Drawing.Font("Verdana", 12F);
            this.radioButton23.Location = new System.Drawing.Point(22, 28);
            this.radioButton23.Margin = new System.Windows.Forms.Padding(0);
            this.radioButton23.Name = "radioButton23";
            this.radioButton23.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.radioButton23.Size = new System.Drawing.Size(118, 33);
            this.radioButton23.TabIndex = 25;
            this.radioButton23.TabStop = true;
            this.radioButton23.Text = "15 0005";
            this.radioButton23.UseVisualStyleBackColor = true;
            // 
            // ReservationNotAvailable
            // 
            this.ReservationNotAvailable.AutoSize = true;
            this.ReservationNotAvailable.Font = new System.Drawing.Font("Verdana", 12F);
            this.ReservationNotAvailable.ForeColor = System.Drawing.Color.Red;
            this.ReservationNotAvailable.Location = new System.Drawing.Point(769, 12);
            this.ReservationNotAvailable.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.ReservationNotAvailable.Name = "ReservationNotAvailable";
            this.ReservationNotAvailable.Size = new System.Drawing.Size(428, 25);
            this.ReservationNotAvailable.TabIndex = 16;
            this.ReservationNotAvailable.Text = "Reservation selected no longer available.";
            this.ReservationNotAvailable.Visible = false;
            // 
            // NoOpenReservationsMessage
            // 
            this.NoOpenReservationsMessage.AutoSize = true;
            this.NoOpenReservationsMessage.Font = new System.Drawing.Font("Verdana", 12F);
            this.NoOpenReservationsMessage.ForeColor = System.Drawing.Color.Red;
            this.NoOpenReservationsMessage.Location = new System.Drawing.Point(126, 14);
            this.NoOpenReservationsMessage.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.NoOpenReservationsMessage.Name = "NoOpenReservationsMessage";
            this.NoOpenReservationsMessage.Size = new System.Drawing.Size(337, 25);
            this.NoOpenReservationsMessage.TabIndex = 15;
            this.NoOpenReservationsMessage.Text = "No Open Reservations for Seller";
            this.NoOpenReservationsMessage.Visible = false;
            // 
            // SellerInfo
            // 
            this.SellerInfo.AutoEllipsis = true;
            this.SellerInfo.Font = new System.Drawing.Font("Verdana", 12F);
            this.SellerInfo.Location = new System.Drawing.Point(12, 332);
            this.SellerInfo.Name = "SellerInfo";
            this.SellerInfo.Size = new System.Drawing.Size(220, 150);
            this.SellerInfo.TabIndex = 34;
            this.SellerInfo.Text = "SELLER INFO";
            // 
            // VehicleDescription
            // 
            this.VehicleDescription.Font = new System.Drawing.Font("Verdana", 12F);
            this.VehicleDescription.Location = new System.Drawing.Point(12, 130);
            this.VehicleDescription.Name = "VehicleDescription";
            this.VehicleDescription.Size = new System.Drawing.Size(220, 150);
            this.VehicleDescription.TabIndex = 33;
            this.VehicleDescription.Text = "VEHICLE DESCRIPTION";
            // 
            // SearchOpenReservations
            // 
            this.SearchOpenReservations.BackColor = System.Drawing.Color.DarkGreen;
            this.SearchOpenReservations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchOpenReservations.Font = new System.Drawing.Font("Verdana", 12F);
            this.SearchOpenReservations.Location = new System.Drawing.Point(164, 54);
            this.SearchOpenReservations.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.SearchOpenReservations.Name = "SearchOpenReservations";
            this.SearchOpenReservations.Size = new System.Drawing.Size(297, 34);
            this.SearchOpenReservations.TabIndex = 10;
            this.SearchOpenReservations.Text = "Search Open Reservations";
            this.SearchOpenReservations.UseVisualStyleBackColor = false;
            this.SearchOpenReservations.Click += new System.EventHandler(this.OnSearchOpenReservations);
            // 
            // SaleDate
            // 
            this.SaleDate.AutoSize = true;
            this.SaleDate.Font = new System.Drawing.Font("Verdana", 12F);
            this.SaleDate.ForeColor = System.Drawing.Color.White;
            this.SaleDate.Location = new System.Drawing.Point(12, 534);
            this.SaleDate.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.SaleDate.Name = "SaleDate";
            this.SaleDate.Size = new System.Drawing.Size(124, 25);
            this.SaleDate.TabIndex = 1;
            this.SaleDate.Text = "SALE DATE";
            // 
            // ViewLineup
            // 
            this.ViewLineup.BackColor = System.Drawing.Color.DarkGreen;
            this.ViewLineup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ViewLineup.Font = new System.Drawing.Font("Verdana", 12F);
            this.ViewLineup.Location = new System.Drawing.Point(475, 54);
            this.ViewLineup.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ViewLineup.Name = "ViewLineup";
            this.ViewLineup.Size = new System.Drawing.Size(297, 34);
            this.ViewLineup.TabIndex = 17;
            this.ViewLineup.Text = "View Seller\'s Lineup";
            this.ViewLineup.UseVisualStyleBackColor = false;
            this.ViewLineup.Click += new System.EventHandler(this.OnViewSellerLineup);
            // 
            // SaleDateLabel
            // 
            this.SaleDateLabel.AutoSize = true;
            this.SaleDateLabel.Font = new System.Drawing.Font("Verdana", 12F);
            this.SaleDateLabel.ForeColor = System.Drawing.Color.White;
            this.SaleDateLabel.Location = new System.Drawing.Point(12, 499);
            this.SaleDateLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.SaleDateLabel.Name = "SaleDateLabel";
            this.SaleDateLabel.Size = new System.Drawing.Size(65, 25);
            this.SaleDateLabel.TabIndex = 0;
            this.SaleDateLabel.Text = "Sale:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkRed;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 12F);
            this.button1.Location = new System.Drawing.Point(8, 8);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 34);
            this.button1.TabIndex = 22;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.OnCancel);
            // 
            // ConfirmReservation
            // 
            this.ConfirmReservation.BackColor = System.Drawing.Color.DarkGreen;
            this.ConfirmReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmReservation.Font = new System.Drawing.Font("Verdana", 12F);
            this.ConfirmReservation.Location = new System.Drawing.Point(861, 8);
            this.ConfirmReservation.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ConfirmReservation.Name = "ConfirmReservation";
            this.ConfirmReservation.Size = new System.Drawing.Size(332, 34);
            this.ConfirmReservation.TabIndex = 12;
            this.ConfirmReservation.Text = "Request Selected Reservation";
            this.ConfirmReservation.UseVisualStyleBackColor = false;
            this.ConfirmReservation.Visible = false;
            this.ConfirmReservation.Click += new System.EventHandler(this.OnConfirmReservation);
            // 
            // AssignLaneLot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(1200, 616);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ConfirmReservation);
            this.Controls.Add(this.FullScreenPanel);
            this.Font = new System.Drawing.Font("Verdana", 15.75F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "AssignLaneLot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AssignLaneLot";
            this.Load += new System.EventHandler(this.AssignLaneLot_Load);
            this.FullScreenPanel.ResumeLayout(false);
            this.FullScreenPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.OpenReservationsList.ResumeLayout(false);
            this.OpenReservationsList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Label label3;
        private Panel FullScreenPanel;
        private Button SearchOpenReservations;
        private Button ViewLineup;
        private Button button1;
        private Label ReservationNotAvailable;
        private Label NoOpenReservationsMessage;
        private RadioButton radioButton23;
        private RadioButton radioButton7;
        private RadioButton radioButton14;
        private RadioButton radioButton15;
        private RadioButton radioButton16;
        private RadioButton radioButton17;
        private RadioButton radioButton24;
        private RadioButton radioButton22;
        private RadioButton radioButton21;
        private RadioButton radioButton20;
        private RadioButton radioButton19;
        private RadioButton radioButton18;
        private RadioButton radioButton25;
        private RadioButton radioButton26;
        private GroupBox OpenReservationsList;
        private Button ConfirmReservation;
        private Label SaleDate;
        private Label SaleDateLabel;
        private Label VehicleDescription;
        private Label SellerInfo;
        private Panel panel2;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private ListView SellerLineup;
        private ColumnHeader AssignedReservations;
        private Label VehicleDescriptionLabel;
        private Label SellerInfoLabel;
    }
}