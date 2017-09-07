/*
 * C17_Ex01: TabDataTables.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Windows.Forms;
using C17_Ex01_Dudi_200441749_Or_204311997.Adapter;
using C17_Ex01_Dudi_200441749_Or_204311997.DataTables;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997.Forms.Tabs
{
    public partial class TabDataTables : UserControl
    {
        private FacebookDataTableManager m_DataTableManager;
        private FacebookDataTable m_DataTableBindedToView;

        public TabDataTables()
        {
            this.InitializeComponent();
        }

        protected override void OnHandleCreated(EventArgs i_Args)
        {
            base.OnHandleCreated(i_Args);
            this.initializeTab();
        }

        private void initializeTab()
        {
            this.m_DataTableManager = new FacebookDataTableManager();
            this.initComboBoxDataTableBindingSelection();
        }

        private void initComboBoxDataTableBindingSelection()
        {
            this.comboBoxDataTableBindingSelection.DisplayMember = "TableName";
            this.comboBoxDataTableBindingSelection.DataSource = this.m_DataTableManager.GetDataTables();
        }

        private void fetchDataForDataTablesTab()
        {
            if (this.comboBoxDataTableBindingSelection.SelectedItem != null)
            {
                this.dataGridView.DataSource = null;
                this.m_DataTableBindedToView = (FacebookDataTable)this.comboBoxDataTableBindingSelection.SelectedItem;
                if (this.m_DataTableBindedToView.DataTable.Rows.Count == 0 || this.m_DataTableBindedToView is FacebookPhotosDataTable)
                {
                    try
                    {
                        FacebookObjectCollection<FacebookObject> collection = this.fetchCollectionWithAdapter(this.m_DataTableBindedToView.GetType());
                        this.m_DataTableBindedToView.PopulateRows(collection);
                        this.timerDataTables.Start();
                    }
                    catch (PopulateRowsException e)
                    {
                        MessageBox.Show(e.Message);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(string.Format("Error while fetching data for data table: {0}", e.Message));
                    }
                }

                this.dataGridView.DataSource = this.m_DataTableBindedToView.DataTable;
                if (this.dataGridView.Columns["ObjectDisplayed"] != null)
                {
                    this.dataGridView.Columns["ObjectDisplayed"].Visible = false;
                }

                if (this.dataGridView.Columns.Count == 0)
                {
                    MessageBox.Show("The requested table could not be loaded, please try again");
                }
            }
        }

        private FacebookObjectCollection<FacebookObject> fetchCollectionWithAdapter(Type i_DataTableType)
        {
            FacebookObjectCollection<FacebookObject> collection;

            if (i_DataTableType.Name == typeof(FacebookPhotosDataTable).Name)
            {
                FormAlbumsSelector formAlbumSelector = new FormAlbumsSelector(FacebookApplication.LoggedInUser);
                IFacebookCollection<Photo> myPhotosAdapter = new FacebookCollectionAdapter<Photo>(eFacebookCollectionType.AlbumPhotos)
                {
                    AlbumsToLoad = formAlbumSelector.GetAlbumsSelection()
                };
                collection = myPhotosAdapter.FetchDataWithProgressBar();
            }
            else if (i_DataTableType.Name == typeof(FacebookLikedPagesDataTable).Name)
            {
                collection = new FacebookCollectionAdapter<Page>(eFacebookCollectionType.LikedPages).FetchDataWithProgressBar();
            }
            else if (i_DataTableType.Name == typeof(FacebookFriendsDataTable).Name)
            {
                collection = new FacebookCollectionAdapter<User>(eFacebookCollectionType.Friends).FetchDataWithProgressBar();
            }
            else if (i_DataTableType.Name == typeof(FacebookPostsDataTable).Name)
            {
                collection = new FacebookCollectionAdapter<Post>(eFacebookCollectionType.MyPosts).FetchDataWithProgressBar();
            }
            else
            {
                throw new NotImplementedException("The given data table type is not supported");
            }

            return collection;
        }

        private void displayDetailsForRowObject(DataGridViewRow i_RowSelected)
        {
            object selectedObject = i_RowSelected.Cells["ObjectDisplayed"].Value;

            this.m_DataTableBindedToView.ObjectToDisplay = selectedObject;
            this.m_DataTableBindedToView.DisplayObject();
        }

        private void refreshDataGridView()
        {
            this.toolStripStatusLabel.Visible = true;
            this.dataGridView.PerformLayout();
            this.dataGridView.Refresh();
            int totalRows = this.m_DataTableBindedToView.TotalRows;
            int loadedRows = this.m_DataTableBindedToView.DataTable.Rows.Count;

            if (totalRows == loadedRows)
            {
                this.toolStripStatusLabel.Text = "All rows loaded";
                this.timerDataTables.Stop();
            }
            else
            {
                this.toolStripStatusLabel.Text = string.Format("loaded {0}/{1} rows", loadedRows, totalRows);
            }
        }

        private void dataGridView_CellDoubleClick(object i_Sender, DataGridViewCellEventArgs i_Args)
        {
            if (((DataGridView)i_Sender).SelectedCells.Count > 0)
            {
                DataGridViewRow rowSelected = ((DataGridView)i_Sender).SelectedCells[0].OwningRow;
                rowSelected.Selected = true;
                this.displayDetailsForRowObject(rowSelected);
            }
        }

        private void dataGridView_CellMouseClick(object i_Sender, DataGridViewCellMouseEventArgs i_Args)
        {
            if (((DataGridView)i_Sender).SelectedCells.Count > 0)
            {
                ((DataGridView)i_Sender).SelectedCells[0].OwningRow.Selected = true;
            }
        }

        private void buttonFetchData_Click(object i_Sender, EventArgs i_Args)
        {
            this.fetchDataForDataTablesTab();
        }

        private void timerDataTables_Tick(object i_Sender, EventArgs i_Args)
        {
            this.refreshDataGridView();
        }
    }
}
