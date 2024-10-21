using Manager.Storage;
using System.Reflection;

namespace Manager.Utility
{
    internal class ListEngine<T, TForm>(List<T> _storageList, ListBox _listBox, string _ident,
        ToolStripButton btnEdit, ToolStripButton btnDelete, ToolStripButton btnMoveUp, ToolStripButton btnMoveDown)
        where TForm : Form, new() where T : NamedClass
    {

        public void Init()
        {
            foreach (var obj in _storageList)
            {
                _listBox.Items.Add(obj);
            }

            UpdateButtons();
        }

        public void UpdateButtons()
        {
            var index = _listBox.SelectedIndex;
            bool selected = index != -1;

            btnEdit.Enabled = selected;
            btnDelete.Enabled = selected;

            btnMoveUp.Enabled = selected && index > 0;
            btnMoveDown.Enabled = selected && index < _listBox.Items.Count-1;
        }

        private static PropertyInfo GetReturningObjProp()
        {
            return typeof(TForm).GetProperty("ReturningObj");
        }

        public void Add()
        {
            var f = new TForm();
            if (f.ShowDialog() == DialogResult.OK)
            {
                var obj = (T)GetReturningObjProp().GetValue(f);

                _storageList.Add(obj);
                _listBox.Items.Add(obj);
                _listBox.SelectedItem = obj;

                ConfigLoader.Save();
            }
        }

        public void Edit()
        {
            var obj = (T)_listBox.SelectedItem;

            var f = new TForm();
            GetReturningObjProp().SetValue(f, obj);
            if (f.ShowDialog() == DialogResult.OK)
            {
                _listBox.Invalidate();

                ConfigLoader.Save();
            }
        }

        public void Delete()
        {
            var obj = (T)_listBox.SelectedItem;

            if (MessageBox.Show($"Delete {_ident} '{obj.Name}'?", $"Delete {_ident}",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _storageList.Remove(obj);
                _listBox.Items.Remove(obj);

                ConfigLoader.Save();
            }
        }

        private void MoveItem(int flag)
        {
            var index = _listBox.SelectedIndex;
            var newIndex = index + flag;

            var obj = (T)_listBox.Items[index];

            _listBox.Items.RemoveAt(index);
            _listBox.Items.Insert(newIndex, obj);
            _listBox.SelectedIndex = newIndex;

            _storageList.RemoveAt(index);
            _storageList.Insert(newIndex, obj);
            ConfigLoader.Save();
        }

        public void MoveUp()
        {
            MoveItem(-1);
        }

        public void MoveDown()
        {
            MoveItem(+1);
        }

    }
}
