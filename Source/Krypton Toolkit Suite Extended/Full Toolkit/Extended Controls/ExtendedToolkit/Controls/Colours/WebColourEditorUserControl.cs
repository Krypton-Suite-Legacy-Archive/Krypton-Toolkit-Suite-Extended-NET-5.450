﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE.md file or at
 * https://github.com/Wagnerp/Krypton-Toolkit-Suite-Extended-NET-5.450/blob/master/LICENSE
 *
 */
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace ExtendedControls.ExtendedToolkit.Controls.Colours
{
    public partial class WebColourEditorUserControl : UserControl
    {
        #region System

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.coloursListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // colorsListView
            // 
            this.coloursListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.coloursListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.coloursListView.FullRowSelect = true;
            this.coloursListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.coloursListView.HideSelection = false;
            this.coloursListView.Location = new System.Drawing.Point(0, 0);
            this.coloursListView.MultiSelect = false;
            this.coloursListView.Name = "colorsListView";
            this.coloursListView.OwnerDraw = true;
            this.coloursListView.ShowGroups = false;
            this.coloursListView.ShowItemToolTips = true;
            this.coloursListView.Size = new System.Drawing.Size(150, 150);
            this.coloursListView.TabIndex = 1;
            this.coloursListView.UseCompatibleStateImageBehavior = false;
            this.coloursListView.View = System.Windows.Forms.View.Details;
            this.coloursListView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ColoursListView_DrawColumnHeader);
            this.coloursListView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ColoursListView_DrawItem);
            this.coloursListView.SelectedIndexChanged += new System.EventHandler(this.ColoursListView_SelectedIndexChanged);
            this.coloursListView.SizeChanged += new System.EventHandler(this.ColoursListView_SizeChanged);
            this.coloursListView.DoubleClick += new System.EventHandler(this.ColoursListView_DoubleClick);
            this.coloursListView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.ColoursListView_DrawSubItem);
            this.coloursListView.Click += new System.EventHandler(this.ColoursListView_Click);
            // 
            // WebColorEditorUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.coloursListView);
            this.Name = "WebColourEditorUserControl";
            this.Load += new System.EventHandler(this.WebColourEditorUserControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView coloursListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;

        #endregion

        private ListViewItem _needEnsureVisibleListViewItem;

        public WebColourEditorUserControl()
        {
            InitializeComponent();
        }

        private void ColoursListView_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Gets the color of the selected.
        /// </summary>
        /// <value>The color of the selected.</value>
        [Browsable(false)]
        public Color SelectedColour
        {
            get
            {
                if (coloursListView.SelectedItems.Count == 1)
                {
                    return (Color)coloursListView.SelectedItems[0].Tag;
                }
                else
                {
                    return Color.Empty;
                }
            }
            set
            {
                if (!DesignMode)
                {
                    foreach (ListViewItem listViewItem in coloursListView.Items)
                    {
                        var colour = (Color)listViewItem.Tag;

                        if (colour == value)
                        {
                            DoSelectItem(listViewItem);
                            return;
                        }
                    }

                    // Not found.
                    coloursListView.SelectedItems.Clear();
                }
            }
        }

        /// <summary>
        /// Does the select item.
        /// </summary>
        /// <param name="listViewItem">The list view item.</param>
        private void DoSelectItem(ListViewItem listViewItem)
        {
            coloursListView.SelectedItems.Clear();

            listViewItem.Selected = true;
            listViewItem.Focused = true;

            listViewItem.EnsureVisible();

            _needEnsureVisibleListViewItem = listViewItem;

            coloursListView.Select();
            coloursListView.Focus();
        }

        /// <summary>
        /// Occurs when the parent needs to update command states.
        /// </summary>
        public event EventHandler NeedUpdateUI;

        private void ColoursListView_DoubleClick(object sender, EventArgs e)
        {

        }

        private void ColoursListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void ColoursListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = false;
        }

        private void ColoursListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = false;

            var color = (Color)e.Item.Tag;

            Brush backgroundBrush;
            Brush textBrush;

            if (e.Item.Selected)
            {
                backgroundBrush = SystemBrushes.Highlight;
                textBrush = SystemBrushes.HighlightText;
            }
            else
            {
                backgroundBrush = SystemBrushes.Window;
                textBrush = SystemBrushes.WindowText;
            }

            e.Graphics.FillRectangle(
                backgroundBrush,
                e.Bounds);

            const int squareDistance = 1;
            var squareWidth = (e.Bounds.Height - 2) * 2 * squareDistance;
            var squareHeight = e.Bounds.Height - 2 * squareDistance;

            var offsetX = e.Bounds.Left + squareDistance;
            var offsetY = e.Bounds.Top + squareDistance;

            var r = new Rectangle(
                offsetX, offsetY,
                squareWidth,
                squareHeight);

            using (Brush brush = new SolidBrush(color))
            {
                e.Graphics.FillRectangle(brush, r);
            }

            var r2 = new Rectangle(
                r.Left, r.Top, r.Width - 1, r.Height - 1);
            var pen = SystemPens.ControlDarkDark;
            e.Graphics.DrawRectangle(pen, r2);

            offsetX += squareWidth + squareDistance * 2;

            var rf = new RectangleF(
                offsetX, e.Bounds.Top,
                e.Bounds.Width - offsetX,
                e.Bounds.Height);

            e.Graphics.DrawString(e.Item.Text, e.Item.Font, textBrush, rf);
        }

        private void WebColourEditorUserControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                CheckEnsureFilled();

                if (_needEnsureVisibleListViewItem != null)
                {
                    DoSelectItem(_needEnsureVisibleListViewItem);
                }

                // --

                ColoursListView_SizeChanged(null, null);
            }
        }

        private void ColoursListView_SizeChanged(object sender, EventArgs e)
        {
            coloursListView.Columns[0].Width = coloursListView.ClientSize.Width - 1;
        }

        private void ColoursListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NeedUpdateUI != null)
            {
                NeedUpdateUI(this, EventArgs.Empty);
            }
        }

        public bool ContainsColor(Color value)
        {
            CheckEnsureFilled();

            foreach (ListViewItem listViewItem in coloursListView.Items)
            {
                var colour = (Color)listViewItem.Tag;

                if (colour == value)
                {
                    return true;
                }
            }

            return false;
        }

        private void CheckEnsureFilled()
        {
            if (coloursListView.Items.Count <= 0)
            {
                var colours = new List<Color>();

                var members = typeof(Color).GetProperties(BindingFlags.Public | BindingFlags.Static);

                foreach (var member in members)
                {
                    if (member.PropertyType == typeof(Color))
                    {
                        var color = (Color)member.GetValue(null, null);

                        colours.Add(color);
                    }
                }

                Trace.WriteLine(@"About to sort colours.");

                var index = 0;

                colours.Sort(
                    delegate (Color c1, Color c2)
                    {
                        Trace.WriteLine(string.Format(@"[{0}.] Sorting colour '{1}' and '{2}'.", index + 1, c1, c2));

                        index++;

                        if (c1 == c2 || c1.Equals(c2))
                        {
                            return 0;
                        }
                        else
                        {
                            if (c1.A < c2.A)
                            {
                                return -1;
                            }
                            if (c1.A > c2.A)
                            {
                                return 1;
                            }
                            if (c1.GetHue() < c2.GetHue())
                            {
                                return -1;
                            }
                            if (c1.GetHue() > c2.GetHue())
                            {
                                return 1;
                            }
                            if (c1.GetSaturation() < c2.GetSaturation())
                            {
                                return -1;
                            }
                            if (c1.GetSaturation() > c2.GetSaturation())
                            {
                                return 1;
                            }
                            if (c1.GetBrightness() < c2.GetBrightness())
                            {
                                return -1;
                            }
                            if (c1.GetBrightness() > c2.GetBrightness())
                            {
                                return 1;
                            }
                            return 0;
                        }
                    });

                Trace.WriteLine(@"Finished sorting colours.");

                // --

                foreach (var colour in colours)
                {
                    var lvi =
                        new ListViewItem
                        {
                            Text = colour.Name,
                            Tag = colour
                        };

                    coloursListView.Items.Add(lvi);
                }
            }
        }
    }
}