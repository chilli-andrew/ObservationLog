using System;
using System.Windows.Forms;

namespace Rusty.ObservationLog.WinForms
{
	/// <summary>
	/// 
	/// </summary>
	class ContextMenus
	{
		bool _isAboutLoaded = false;

	    private bool _isReportLoaded = false;

		public ContextMenuStrip Create()
		{
			// Add the default menu options.
			ContextMenuStrip menu = new ContextMenuStrip();
			ToolStripMenuItem item;
			ToolStripSeparator sep;

			// About.
			item = new ToolStripMenuItem();
			item.Text = "About";
			item.Click += new EventHandler(About_Click);
			item.Image = Resources.About;
			menu.Items.Add(item);

			// Separator.
			sep = new ToolStripSeparator();
			menu.Items.Add(sep);

			// Report.
			item = new ToolStripMenuItem();
			item.Text = "Report";
			item.Click += new System.EventHandler(Report_Click);
			item.Image = Resources.Report;
			menu.Items.Add(item);			
            
            // Separator.
			sep = new ToolStripSeparator();
			menu.Items.Add(sep);

			// Exit.
			item = new ToolStripMenuItem();
			item.Text = "Exit";
			item.Click += new System.EventHandler(Exit_Click);
			item.Image = Resources.Exit;
			menu.Items.Add(item);

			return menu;
		}

		void About_Click(object sender, EventArgs e)
		{
			if (!_isAboutLoaded)
			{
				_isAboutLoaded = true;
				new AboutBox().ShowDialog();
				_isAboutLoaded = false;
			}
		}

        void Report_Click(object sender, EventArgs e)
        {
            if (!_isReportLoaded)
            {
                _isReportLoaded = true;
                new ObservationsReport().ShowDialog();
                _isReportLoaded = false;
            }
        }

		void Exit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}