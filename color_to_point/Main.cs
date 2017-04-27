using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OpenCvSharp;
using System.IO;

namespace color_to_point
{
    public partial class Main : Form
    {
        List<String> 入力画像path = new List<String>();

        Scalar[] Scalar_右手 = new Scalar[]{ new Scalar(20, 100, 100), new Scalar(35, 255, 255) };
        Scalar[] Scalar_左手 = new Scalar[] { new Scalar(140, 90, 51), new Scalar(160,153, 90) };
        Scalar[] Scalar_右足 = new Scalar[] { new Scalar(62, 102, 26), new Scalar(80, 229, 68) };
        Scalar[] Scalar_左足 = new Scalar[] { new Scalar(108, 178, 51), new Scalar(112, 255, 77)};
        Scalar[] Scalar_胴   = new Scalar[] { new Scalar(100, 173, 137), new Scalar(105, 255, 180) };

        public Main()
        {
            InitializeComponent();
        }

        private void Click_open(object sender, EventArgs e)
        {
            if (入力画像path != null) 入力画像path.Clear();
             //OpenFileDialogクラスのインスタンスを作成
             OpenFileDialog ofd = new OpenFileDialog();
            //複数のファイルを選択できるようにする
            ofd.Multiselect = true;
            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、選択されたファイル名をすべて表示する
                foreach (string fn in ofd.FileNames)
                {
                    入力画像path.Add(fn);
                    Console.WriteLine(fn);
                }
                pictureBoxIpl.ImageIpl= new Mat(入力画像path[0]);
            }

        }

        private void Click_表示(object sender, EventArgs e)
        {
            if (入力画像path != null)
            {
                pictureBoxIpl.ImageIpl=new Mat(入力画像path[int.Parse(textBox_index.Text)]);
            }
        }


        private void hsv_mask(Mat src_color, Scalar lowerb, Scalar upperb,ref Mat dst_gray)//グレースケールで返す
        {
            GC.Collect();

            if (src_color.Channels() >= 3)
            {
                Cv2.CvtColor(src_color, dst_gray, ColorConversionCodes.BGR2HSV);
                Cv2.InRange(dst_gray, lowerb, upperb, dst_gray);//ここでhsvがgrayに変換されるっぽい

                var kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(3,3));
                Cv2.MorphologyEx(dst_gray, dst_gray, MorphTypes.Close, kernel, null, 2);

            }
            else { MessageBox.Show("this image is not color!"); }
            
        }

        private void find_max_area(Mat src_gray, ref OpenCvSharp.Point center,ref Mat dst_color)//カラーで返す
        {
            src_gray.Threshold(0, 255, ThresholdTypes.Otsu | ThresholdTypes.Binary);
            Mat[] contours;
            Mat hie = new Mat();

            Cv2.FindContours(src_gray, out contours, hie, RetrievalModes.External, ContourApproximationModes.ApproxSimple);
            if (contours.Length > 0)
            {
                double max_size = 0;
                int max_index = 0;

                for (int i = 0; i < contours.Length; i++)
                {
                    double size = Cv2.ContourArea(contours[i]);
                    if (max_size < size)
                    {
                        max_size = size;
                        max_index = i;
                    }
                }
                Cv2.DrawContours(dst_color, contours, max_index, new Scalar(255, 255, 255), -1);
                RotatedRect box = Cv2.MinAreaRect(contours[max_index]);
                center = box.Center;

            }

            contours = null;
            hie.Dispose();
            src_gray.Dispose();
        }

        private OpenCvSharp.Point find_max_area_point(Mat src_gray)
        {
            OpenCvSharp.Point center = new Point(0, 0);
            src_gray.Threshold(0, 255, ThresholdTypes.Otsu | ThresholdTypes.Binary);
            Mat[] contours;
            Mat hie = new Mat();

            Cv2.FindContours(src_gray, out contours, hie, RetrievalModes.External, ContourApproximationModes.ApproxSimple);
            if (contours.Length > 0)
            {
                double max_size = 0;
                int max_index = 0;

                for (int i = 0; i < contours.Length; i++)
                {
                    double size = Cv2.ContourArea(contours[i]);
                    if (max_size < size)
                    {
                        max_size = size;
                        max_index = i;
                    }
                }
                RotatedRect box = Cv2.MinAreaRect(contours[max_index]);
                center = box.Center;

            }
            else { Console.WriteLine("no area found!"); }

            src_gray.Dispose();
            contours = null;
            hie.Dispose();
            

            return center;
        }

        private void Click_csv出力(object sender, EventArgs e)
        {
            //System.IO.Directory.CreateDirectory(@"result");
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(textBox_Points.Text);


            //System.IO.Directory.CreateDirectory(@"result");//resultフォルダの作成
            SaveFileDialog sfd = new SaveFileDialog();//SaveFileDialogクラスのインスタンスを作成
                                                      //sfd.FileName = textBox_Gaus.Text + "_" + textBox_Bright.Text + "_" + textBox_Cont.Text;//はじめのファイル名を指定する
                                                      //sfd.InitialDirectory = @"result\";//はじめに表示されるフォルダを指定する
            sfd.Filter = "csvファイル|*.csv;*.txt;|全てのファイル|*.*";//[ファイルの種類]に表示される選択肢を指定する
            sfd.FilterIndex = 1;//[ファイルの種類]ではじめに「画像ファイル」が選択されているようにする
            sfd.Title = "保存先のファイルを選択してください";//タイトルを設定する
            sfd.RestoreDirectory = true;//ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            sfd.OverwritePrompt = true;//既に存在するファイル名を指定したとき警告する．デフォルトでTrueなので指定する必要はない
            sfd.CheckPathExists = true;//存在しないパスが指定されたとき警告を表示する．デフォルトでTrueなので指定する必要はない

            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき
                //選択されたファイル名を表示する
                System.Diagnostics.Debug.WriteLine(sfd.FileName);
                using (StreamWriter w = new StreamWriter(sfd.FileName))
                {
                    w.Write(sb);
                    w.Dispose();
                }
            }
        


        }

        private void 色抽出_面積最大マスク(Mat src_color, Scalar lowerb,Scalar upperb, ref Mat dst_color, ref Point center)//src->color dst->gray
        {
            Mat mask = new Mat(src_color.Size(),MatType.CV_8UC1);

            hsv_mask(src_color, lowerb, upperb, ref mask);

            if (dst_color != null) find_max_area(mask, ref center, ref dst_color);
            else center=find_max_area_point(mask);

            mask.Dispose();
            
        }
        private void マスク合成(Mat[] src_color,ref Mat dst_color)
        {
            foreach (Mat src in src_color)Cv2.BitwiseOr(src, dst_color, dst_color);
        }

        private void 定義済み色抽出(Mat src, ref Mat dst)
        {
            String point_info = "";
            Mat mask_combine = new Mat(src.Size(), MatType.CV_8UC3);

            
            OpenCvSharp.Point point_右手  = new Point();
            OpenCvSharp.Point point_左手 = new Point();
            OpenCvSharp.Point point_右足  = new Point();
            OpenCvSharp.Point point_左足  = new Point();
            OpenCvSharp.Point point_胴  = new Point();

            Mat mask_右手  = new Mat(src.Size(), MatType.CV_8UC3);
            Mat mask_左手 = new Mat(src.Size(), MatType.CV_8UC3);
            Mat mask_右足  = new Mat(src.Size(), MatType.CV_8UC3);
            Mat mask_左足  = new Mat(src.Size(), MatType.CV_8UC3);
            Mat mask_胴  = new Mat(src.Size(), MatType.CV_8UC3);

            色抽出_面積最大マスク(src, Scalar_右手[0],Scalar_右手[1],ref mask_右手 , ref point_右手);
            色抽出_面積最大マスク(src, Scalar_左手[0],Scalar_左手[1],ref mask_左手 , ref point_左手);
            色抽出_面積最大マスク(src, Scalar_右足[0],Scalar_右足[1],ref mask_右足, ref point_右足);
            色抽出_面積最大マスク(src, Scalar_左足[0],Scalar_左足[1],ref mask_左足, ref point_左足);
            色抽出_面積最大マスク(src, Scalar_胴[0],    Scalar_胴[1], ref mask_胴, ref point_胴);


            マスク合成(new Mat[] {
                mask_右手 ,
                mask_左手 ,
                mask_右足 ,
                mask_左足,
                mask_胴
                 
            },ref mask_combine);

            mask_右手.Dispose();
            mask_左手.Dispose();
            mask_右足.Dispose();
            mask_左足.Dispose();
            mask_胴.Dispose();
     

            point_info +=""+ point_右手.X + ',' + point_右手.Y + ',';
            point_info +=""+ point_左手.X + ',' + point_左手.Y + ',';
            point_info +=""+ point_右足.X + ',' + point_右足.Y + ',';
            point_info +=""+ point_左足.X + ',' + point_左足.Y + ',';
            point_info +=""+ point_胴.X + ',' + point_胴.Y   ;

            textBox_Points.Text = point_info;

            Cv2.BitwiseAnd(src, mask_combine, dst);
            mask_combine.Dispose();
            
        }

        private void カスタム色抽出(Mat src, ref Mat dst)
        {
            textBox_Points.Text = "";
            Mat mask = new Mat(src.Size(), MatType.CV_8UC3);
            string[] upperb = textBox_max.Text.Split(',');
            string[] lowerb= textBox_min.Text.Split(',');
            Point center = new Point(0, 0);            

            色抽出_面積最大マスク(src, new Scalar(double.Parse(lowerb[0]), double.Parse(lowerb[1]), double.Parse(lowerb[2])),
                new Scalar(double.Parse(upperb[0]), double.Parse(upperb[1]), double.Parse(upperb[2])),ref mask,ref center);

            byte[] hsv_min_max = マスク領域の最大最小HSV値取得(src, mask);
            Cv2.BitwiseAnd(src, mask, dst);

            textBox_Points.Text += center.ToString()+"\r\n";
            foreach (int val in hsv_min_max) textBox_Points.Text += val + ",";
             mask.Dispose();            
        }

        private byte[] マスク領域の最大最小HSV値取得(Mat src_color, Mat mask_color)
        {
            int width = src_color.Width;
            int height = src_color.Height;
            byte[] max_hsv = { 0,0,0};
            byte[] min_hsv = {255,255,255};
            Mat hsv = new Mat(src_color.Size(),MatType.CV_8UC3);
            Mat mask_gray = new Mat(src_color.Size(), MatType.CV_8UC1);
            Cv2.CvtColor(mask_color, mask_gray, ColorConversionCodes.BGR2GRAY);
            Cv2.CvtColor(src_color,hsv,ColorConversionCodes.BGR2HSV);
            mask_gray.Threshold(0, 255, ThresholdTypes.Otsu | ThresholdTypes.Binary);

            
            //なんか不安定
            var indexer_hsv = new MatOfByte3(hsv).GetIndexer();
            var indexer_mask = new MatOfByte3(mask_gray).GetIndexer();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Vec3b color_hsv = indexer_hsv[y,x];
                    Vec3b color_mask = indexer_mask[y, x];

                    if (color_mask.Item0 != 0)
                    {
                        if (color_hsv.Item0 > max_hsv[0]) max_hsv[0] = color_hsv.Item0;
                        if (color_hsv.Item1 > max_hsv[1]) max_hsv[1] = color_hsv.Item1;
                        if (color_hsv.Item2 > max_hsv[2]) max_hsv[2] = color_hsv.Item2;
                        if (color_hsv.Item0 < min_hsv[0]) min_hsv[0] = color_hsv.Item0;
                        if (color_hsv.Item1 < min_hsv[1]) min_hsv[1] = color_hsv.Item1;
                        if (color_hsv.Item2 < min_hsv[2]) min_hsv[2] = color_hsv.Item2;
                    }
                }
            }

            mask_gray.Dispose();
            hsv.Dispose();

            return new byte[]{ min_hsv[0], min_hsv[1], min_hsv[2], max_hsv[0], max_hsv[1], max_hsv[2] };
        }

        private void Click_1画像処理(object sender, EventArgs e)
        {
            //GC.Collect();
            if (pictureBoxIpl.ImageIpl != null)
            {
                Mat dst = new Mat(pictureBoxIpl.ImageIpl.Size(), MatType.CV_8UC3);

                if (checkBox_th_enable.Checked) カスタム色抽出(pictureBoxIpl.ImageIpl, ref dst);
                else 定義済み色抽出(pictureBoxIpl.ImageIpl, ref dst);

                pictureBoxIpl.ImageIpl=dst;
            }
        }

        private void Click_全画像処理(object sender, EventArgs e)
        {
            //GC.Collect();
            string points = "";
            textBox_Points.Text = "";
            progressBar_全画像処理.Maximum = 入力画像path.Count;
            progressBar_全画像処理.Value = 0;

            foreach (string image_path in 入力画像path)
            {
                Mat org = new Mat(image_path);


                OpenCvSharp.Point point_右手 = new Point();
                OpenCvSharp.Point point_左手 = new Point();
                OpenCvSharp.Point point_右足 = new Point();
                OpenCvSharp.Point point_左足 = new Point();
                OpenCvSharp.Point point_胴  = new Point();
                

                Mat null_mat = new Mat();
                null_mat = null;
                色抽出_面積最大マスク(org,Scalar_右手[0],Scalar_右手[1],ref null_mat, ref point_右手);
                色抽出_面積最大マスク(org,Scalar_左手[0],Scalar_左手[1],ref null_mat, ref point_左手);
                色抽出_面積最大マスク(org,Scalar_右足[0],Scalar_右足[1],ref null_mat, ref point_右足);
                色抽出_面積最大マスク(org,Scalar_左足[0],Scalar_左足[1],ref null_mat, ref point_左足);
                色抽出_面積最大マスク(org, Scalar_胴[0], Scalar_胴[1], ref null_mat, ref point_胴);

                //Console.WriteLine(point_pink);
                points += "" + point_右手.X + ',' + point_右手.Y + ',';
                points += "" + point_左手.X + ',' + point_左手.Y + ',';
                points += "" + point_右足.X + ',' + point_右足.Y + ',';
                points += "" + point_左足.X + ',' + point_左足.Y + ',';
                points += "" + point_胴.X + ',' + point_胴.Y+"\r\n";

                org.Dispose();

                progressBar_全画像処理.Value++;
            }

            textBox_Points.Text = points;
        }
    }
}
