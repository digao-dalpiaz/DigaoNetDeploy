using Manager.Storage;

namespace Manager
{
    internal class ListEngine<T, TForm>(List<T> _storageList, ListBox _listBox, string _ident) where TForm : ReturningForm<T>, new() where T : NamedClass
    {

        public void FillList()
        {
            foreach (var obj in _storageList)
            {
                _listBox.Items.Add(obj);
            }
        }

        public void Add()
        {
            var f = new TForm();
            if (f.ShowDialog() == DialogResult.OK)
            {
                var obj = f.ReturningObj;

                _storageList.Add(obj);
                _listBox.Items.Add(obj);
                _listBox.SelectedItem = obj;

                ConfigLoader.Save();
            }
        }

        public void Edit()
        {
            var obj = (T)_listBox.SelectedItem;
            if (obj == null) return;

            var f = new TForm();
            f.ReturningObj = obj;
            if (f.ShowDialog() == DialogResult.OK)
            {
                _listBox.Invalidate();

                ConfigLoader.Save();
            }
        }

        public void Delete()
        {
            var obj = (T)_listBox.SelectedItem;
            if (obj == null) return;

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
            if (index == -1) return;

            var newIndex = index + flag;
            if (newIndex < 0 || newIndex > _listBox.Items.Count-1) return;

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

    public class ReturningForm<T> : Form
    {
        public T ReturningObj { get; set; }
    }
}
