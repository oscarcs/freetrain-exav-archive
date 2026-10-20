using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using freetrain.framework;
using freetrain.framework.plugin;
using freetrain.util;

namespace freetrain.world.accounting
{
    public class HistoryViewMonths : Form
    {


		/// <summary>
		/// Persistent setting.
		/// </summary>
		private Options options = new Options().load();


		/// <summary>
		/// Persistent information of this dialog.
		/// </summary>
		public class Options : PersistentOptions
		{
			/// <summary> display font. </summary>
			public FontInfo font;

			/// <summary>
			/// List of displayed genre ids.
			/// Public only for XmlSerializer.
			/// </summary>
			[XmlElement("genre")]
			public string[] _genre;

			[XmlIgnore()]
			public AccountGenre[] genres {
				get {
					try {
						AccountGenre[] r = new AccountGenre[_genre.Length];
						for( int i=0; i<r.Length; i++ )
							r[i] = (AccountGenre)PluginManager.theInstance.getContribution(_genre[i]);
						return r;
					} catch( Exception e ) {
						// recover from missing plug-in error by returning a default list.
						return new AccountGenre[] {
							AccountGenre.RAIL_SERVICE,
							AccountGenre.ROAD_SERVICE,
							AccountGenre.SUBSIDIARIES
						};
					}
				}
				set {
					_genre = new string[value.Length];
					for( int i=0; i<value.Length; i++ )
						_genre[i] = value[i].id;
					save();
				}
			}

			public new Options load() {
				return (Options)base.load();
			}
		}
		



      
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.selectSalesButton = new System.Windows.Forms.RadioButton();
            this.selectExpendituresButton = new System.Windows.Forms.RadioButton();
            this.selectBalanceButton = new System.Windows.Forms.RadioButton();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // selectSalesButton
            // 
            this.selectSalesButton.AutoSize = true;
            this.selectSalesButton.Location = new System.Drawing.Point(13, 43);
            this.selectSalesButton.Name = "selectSalesButton";
            this.selectSalesButton.Size = new System.Drawing.Size(47, 16);
            this.selectSalesButton.TabIndex = 2;
            this.selectSalesButton.TabStop = true;
            this.selectSalesButton.Text = "売上";
            this.selectSalesButton.UseVisualStyleBackColor = true;
            // 
            // selectExpendituresButton
            // 
            this.selectExpendituresButton.AutoSize = true;
            this.selectExpendituresButton.Location = new System.Drawing.Point(105, 43);
            this.selectExpendituresButton.Name = "selectExpendituresButton";
            this.selectExpendituresButton.Size = new System.Drawing.Size(47, 16);
            this.selectExpendituresButton.TabIndex = 3;
            this.selectExpendituresButton.TabStop = true;
            this.selectExpendituresButton.Text = "経費";
            this.selectExpendituresButton.UseVisualStyleBackColor = true;
            // 
            // selectBalanceButton
            // 
            this.selectBalanceButton.AutoSize = true;
            this.selectBalanceButton.Location = new System.Drawing.Point(197, 42);
            this.selectBalanceButton.Name = "selectBalanceButton";
            this.selectBalanceButton.Size = new System.Drawing.Size(47, 16);
            this.selectBalanceButton.TabIndex = 4;
            this.selectBalanceButton.TabStop = true;
            this.selectBalanceButton.Checked = true;
            this.selectBalanceButton.Text = "収支";
            this.selectBalanceButton.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(13, 65);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(549, 189);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.Columns.Add("分類", 80);
            // 
            // HistoryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 266);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.selectBalanceButton);
            this.Controls.Add(this.selectExpendituresButton);
            this.Controls.Add(this.selectSalesButton);
            this.Name = "HistoryView";
            this.Text = "売上履歴";
            this.ResumeLayout(false);
            this.PerformLayout();

            for( int i=1; i<13; i++ ){
                string title = i.ToString() + "ヶ月前";
                this.listView1.Columns.Add( title, 80, HorizontalAlignment.Center );
            }
          
        }

        #endregion

        private System.Windows.Forms.RadioButton selectSalesButton;
        private System.Windows.Forms.RadioButton selectExpendituresButton;
        private System.Windows.Forms.RadioButton selectBalanceButton;
        private System.Windows.Forms.ListView listView1;
    
        public HistoryViewMonths()
        {
            InitializeComponent();

			populateListView();
        }


        /// <summary>
		/// Set up items in the list view according to <code>options.genres</code>.
		/// </summary>
		private void populateListView() {
			listView1.BeginUpdate();
			listView1.Items.Clear();
			foreach( AccountGenre g in options.genres ) {
				ListViewItem lvi = new GenreListItem(this,g);
				listView1.Items.Add(lvi);
			}
			updateItems();	// fill in the sub texts
			listView1.EndUpdate();			
		}

		/// <summary>
		/// Update the displayed data of list view items.
		/// </summary>
		private AccountListener updateItems;

		/// <summary>
		/// Manage ListViewItem and display information about an account genre.
		/// </summary>
		private class GenreListItem : ListViewItem, IDisposable {
			private readonly AccountGenre genre;
			private readonly HistoryViewMonths parent;

			/// <summary> History object that whose value we are displaying. </summary>
			private TransactionHistory history { get { return genre.history; } }

			internal GenreListItem( HistoryViewMonths _parent, AccountGenre genre ) {
				this.parent = _parent;
				this.genre = genre;
				this.Text = genre.name;

				for( int i=1; i<13; i++ )
                    this.SubItems.Add("0");

                onUpdateMonths12();

				genre.onUpdate += new AccountListener(onUpdateMonths12);
				parent.updateItems += new AccountListener(onUpdateMonths12);
			}
 
			public void Dispose() {
				// disconnect
				genre.onUpdate -= new AccountListener(onUpdateMonths12);
				parent.updateItems -= new AccountListener(onUpdateMonths12);
			}

            /// <summary> Update data on the screen. </summary>
			private void onUpdateMonths12() {
				TransactionAgoSummary s = history.monthAgo;
                for( int i=0 ; i<12 ; i++ ){
                  //  if( selectSalesButton.Checked )
				  //      this.SubItems[i+1].Text = CurrencyUtil.format(s.sales(i));
                  //  if( selectExpendituresButton.Checked )
				  //      this.SubItems[i+1].Text = CurrencyUtil.format(s.expenditures(i));
                  //  if( selectBalanceButton.Checked )
				        this.SubItems[i+1].Text = CurrencyUtil.format(s.balance(i));
                }
			}
		}

		
    }
}
