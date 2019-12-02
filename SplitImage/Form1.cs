//Đừng tắt bật nhạc trong khi vẽ hình

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplitImage
{
    struct Cell {
        public int ID;
        public Bitmap cell_Bitmap;
    }
    public partial class form_SplitImage : Form
    {
        private string str_ImageSources;
        private string str_FolderDes;
        SoundPlayer sound = new SoundPlayer();

        public form_SplitImage()
        {
            InitializeComponent();
 
        }

        private void form_SplitImage_Load(object sender, EventArgs e)
        {
            //button
            gb_Infor.Location = new Point(this.Width / 2 - gb_Infor.Width / 2, this.Height / 2 - gb_Infor.Height / 2 - 20);
            bt_Export.Location = new Point(gb_Infor.Location.X + gb_Infor.Width / 2 - bt_Export.Width / 2, gb_Infor.Location.Y + gb_Infor.Height - bt_Export.Height / 2);
            tb__CellSize.ShortcutsEnabled = false;
            tb_numRows.ShortcutsEnabled = false;

            sound.SoundLocation = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "..\\.." + "\\closetothesun.wav"));

            music_state.Text = "Tắt nhạc";
            playMusicBg();
        }

        private void tb__CellSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tb_numRows_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void bt_ChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png, *.jpeg, *.bmp) |*.png; *.jpeg; *.bmp";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = false;


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tb_FileName.Text = openFileDialog.SafeFileName;
                str_ImageSources = openFileDialog.FileName;
            }
        }

        private void bt_ChooseFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                tb_Folder.Text = folderBrowser.SelectedPath;
                str_FolderDes = folderBrowser.SelectedPath;
            }
        }

        private void bt_Export_Click(object sender, EventArgs e)
        {
            lb_caution.ForeColor = Color.DarkRed;

            if (tb_FileName.Text == "")
            {
                lb_caution.Text = "Vui lòng chọn đường dẫn cho file cần cắt!";
                return;
            }

            if (tb_Folder.Text == "")
            {
                lb_caution.Text = "Vui lòng chọn đường dẫn cho thư mục cần lưu file!";
                return;
            }

            if (tb__CellSize.Text == "" || tb__CellSize.Text == "0")
            {
                lb_caution.Text = "Vui lòng nhập kích thước cell cần cắt!";
                return;
            }

            if (tb_numRows.Text == "" || tb_numRows.Text == "0")
            {
                lb_caution.Text = "Vui lòng nhập số lượng dòng cần xuất ra!";
                return;

            }

            Bitmap mainImage = new Bitmap(str_ImageSources);
            var big_image_width = mainImage.Width;
            var big_image_height = mainImage.Height;

            int cell_size;
            int num_rows;
            Int32.TryParse(tb__CellSize.Text, out cell_size);
            Int32.TryParse(tb_numRows.Text, out num_rows);

            var big_image_columns = big_image_width / cell_size + 1;
            var big_image_rows = big_image_height / cell_size + 1;

            List<Cell> listCell = new List<Cell>();
            int count_num = 1;
            int cellTotal = 0;

            //Tạo file text cho grid map
            //Nhiệm vụ ưu tiên là ghi lên file
            // CreateFileText(str_FolderDes + "\\" + "tile_map.txt");
            try
            {
                File.WriteAllText(str_FolderDes + "\\" + "tile_map.txt", String.Empty);
                FileStream fileStream = new FileStream(str_FolderDes + "\\" + "tile_map.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fileStream);
            
                lb_caution.ForeColor = Color.Green;

                bt_Export.Enabled = false;
            

                for (int i = 0; i < big_image_height; i = i + cell_size)
                {
                    if (i != 0)
                    {
                        writer.Write("\n");
                    }
                    for (int j = 0; j < big_image_width; j = j + cell_size)
                    {
                        Rectangle section = new Rectangle(new Point(j , i), new Size(cell_size, cell_size));
                        Cell cell = new Cell();
                        cell.cell_Bitmap = CropImage(mainImage, section);

                        if (CompareImage(cell.cell_Bitmap, new Bitmap(cell_size, cell_size)))
                            cell.ID = 0;
                        else  
                            cell.ID = count_num;

                        bool similar = false;
                        if (cellTotal == 0)
                        {
                            listCell.Add(cell);
                            writer.Write(cell.ID.ToString() + " ");
                            cellTotal += 1;
                            if (!CompareImage(cell.cell_Bitmap, new Bitmap(cell_size, cell_size)))
                                count_num += 1;
                        }
                        else
                        {
                            for (int k = 0; k < listCell.Count; k++)
                            {
                                if (CompareImage(cell.cell_Bitmap, listCell[k].cell_Bitmap))
                                {
                                    writer.Write(listCell[k].ID.ToString() + " ");//ghi ID trùng vào file text
                                    similar = true;
                                    Console.WriteLine(listCell[k].ID.ToString());
                                    break;
                                }
                            }

                            if (similar)//nếu giống nhau
                            {
                                cellTotal += 1;
                                lb_caution.Text = "Đang ghi file... (@_@) " + (((float)cellTotal / (big_image_columns * big_image_rows)) * 100) + "%";
                                lb_caution.Refresh();
                            }
                            else
                            {
                                writer.Write(cell.ID.ToString() + " ");//ghi ID mới vào trong file text
                                listCell.Add(cell);
                                count_num += 1;
                                cellTotal += 1;
                                Console.WriteLine(count_num.ToString());
                                lb_caution.Text = "Đang ghi file... (@_@) " + (((float)cellTotal / (big_image_columns * big_image_rows)) * 100) + "%";
                                lb_caution.Refresh(); 
                            }
                        }
                    }
                }

                //Xóa bộ nhớ đệm của file text
                writer.Flush();
                //Đóng ghi file
                writer.Close();
                //////////////////////////////////
                ///Nhiệm vụ tạo sprite tile map
                //Dán hình vào bitmap lớn///////
                //Định nghĩa cột hàng của tile map
                var grid_columns = listCell.Count / num_rows + 1;
                var grid_rows = num_rows;
                //Tạo bitmap thể hiện cũa tileSet
                Bitmap map_bitmap = new Bitmap(cell_size * grid_columns, cell_size * grid_rows);
                Graphics g = Graphics.FromImage(map_bitmap);
                //vòng lặp ghi ảnh bitmap từng cell lên bitmap lớn
                var count_nember = 0;
                for(int i = 0; i <= grid_rows; i++)
                    for (int j = 0; j  < grid_columns; j++)
                    {
                        if (count_nember >= listCell.Count)
                            break;

                        g.DrawImage(listCell[count_nember].cell_Bitmap, new Point(j * cell_size, i * cell_size));
                        lb_caution.Text = "Đang vẽ hình... (!_!) " + (((float)count_nember / listCell.Count) * 100) + "%";
                        lb_caution.Refresh();
                        count_nember += 1;
                    }

                map_bitmap.Save(str_FolderDes + "\\" + "tile_map.png");
                //=====================================
                //Them header row, column cho file text
                //=====================================
                lb_caution.Text = "Reformat...";
                lb_caution.Refresh();

                //ghi nội dung file text vào data
                string data = File.ReadAllText(str_FolderDes + "\\" + "tile_map.txt");
                //thêm header cho data
                string header_data = big_image_rows + " " + big_image_columns + "\n" + data;
                //xóa nội dung trong file
                File.WriteAllText(str_FolderDes + "\\" + "tile_map.txt", String.Empty);
                //Ghi nội dung đã có header vào file text
                File.WriteAllText(str_FolderDes + "\\" + "tile_map.txt", header_data);
                
                Application.DoEvents();//Bỏ qua các sự kiện khi bt_Export disable;
                bt_Export.Enabled = true;
                Console.WriteLine(listCell.Count);

                lb_caution.Text = "Xong!";
            }
            catch
            {
                lb_caution.ForeColor = Color.DarkRed;
                lb_caution.Text = "Có lỗi xảy ra! Kiểm tra lại input. Lưu ý: Không được chọn thư mục đích trong ổ hệ thống! Không nhập kích thước cell lớn hơn ảnh hay số dòng không hợp lệ!";
                return;
            }
        }

        //So sánh hai ảnh
        private bool CompareImage(Bitmap bmp1, Bitmap bmp2)
        {
            string img1, img2;
            
            if (bmp1.Width == bmp2.Width && bmp1.Height == bmp2.Height)
            {
                for (int i = 0; i < bmp1.Width; i++)
                    for (int j = 0; j < bmp1.Height; j++)
                    {
                        img1 = bmp1.GetPixel(i, j).ToString();
                        img2 = bmp2.GetPixel(i, j).ToString();
                        if (img1 != img2) return false;
                    }
            }
            return true;
        }


        //Hàm cắt ảnh
        private Bitmap CropImage(Bitmap src, Rectangle section)
        {
            var bitmap = new Bitmap(section.Width, section.Height);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(src, 0, 0, section, GraphicsUnit.Pixel);
                return bitmap;
            }
        }
 
        private void playMusicBg()
        {
            try
            {
                Console.WriteLine(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "..\\.." + "\\closetothesun.wav")));
                Console.WriteLine(Environment.CurrentDirectory);
                sound.PlayLooping();
            }
            catch { }
        }

        private void music_state_Click(object sender, EventArgs e)
        {
            if (music_state.Text == "Tắt nhạc")
            {
                sound.Stop();
                music_state.Text = "Bật nhạc";
            }
            else if (music_state.Text == "Bật nhạc")
            {
                sound.PlayLooping();
                music_state.Text = "Tắt nhạc";
            }
        }
    }
}
