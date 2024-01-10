using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JA_Neon
{
    enum Library
    {
        Assembly, Cpp, Unknown
    }
    public partial class MainForm : Form
    {
        private Bitmap InputPicture = null;
        private Bitmap OutputPicture = null;

        private Library library = Library.Assembly;
        private int cores = 8;
        private bool rerun = false;
        private int MaskBlur = 1;
        private int MaskIntensity = 100;
        private int NeonIntensity = 75;

        #region MAIN
        public MainForm()
        {
            InitializeComponent();
        }
        private void Constructor(object sender, EventArgs e)
        {
            slider_cores.Value = cores;
            slider_MaskBlur.Value = MaskBlur;
            slider_MaskIntensity.Value = MaskIntensity;
            slider_NeonIntensity.Value = NeonIntensity;
            select_Library.SelectedIndex = 1;

            Console_AddLine("Application ready!");
        }
        private void Run(object sender, EventArgs e)
        {
            label_ProgressBar.Text = "Beginning...";
            if (InputPictureBox.Image == null)
            {
                Console_AddLine("No input image selected!");
                return;
            }
            ProgressBar.Value = 0;
            Console_AddLine("Running...");
            ProgressBar.Value = 10;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            InputPicture = new Bitmap(InputPictureBox.Image);
            OutputPicture = new Bitmap(InputPicture.Width, InputPicture.Height);
            OutputPictureBox.Image = OutputPicture;
            if (library == Library.Assembly)
            {
                // Run assembly code
                Console_AddLine("Running assembly code...");
                OutputPicture = RunAssembly(InputPicture, cores, MaskBlur, MaskIntensity, NeonIntensity);
            }
            else if (library == Library.Cpp)
            {
                // Run C++ code
                ProgressBar.Value = 50;
                Console_AddLine("Running C++ code...");
                ProgressBar.Value = 80;
                // OutputPicture = RunCpp(InputPicture, cores, MaskBlur, MaskIntensity, NeonIntensity);

                int px = 0;
                for (int x = 0; x < InputPicture.Width; x++)
                {
                    for (int y = 0; y < InputPicture.Height; y++)
                    {
                        px++;
                        label_ProgressBar.Text = "Processing " + px / InputPicture.Width / InputPicture.Height * 100 + "%";
                        ProgressBar.Value = px / InputPicture.Width / InputPicture.Height * 100;
                        OutputPicture.SetPixel(x, y, BumpSaturarionBitmap(InputPicture.GetPixel(x, y), NeonIntensity));
                        OutputPictureBox.Image = OutputPicture;
                    }
                }
            }
            else
            {
                Console_AddLine("Unknown Library!");
                return;
            }
            Console_AddLine("Image Processed!");

            OutputPictureBox.Image = OutputPicture;
            //label_Output.Visible = false;
            //label_ClickToSave.Visible = false;

            stopwatch.Stop();
            reading_time.Text = FormatTime(stopwatch.ElapsedMilliseconds);
            ProgressBar.Value = 100;
            Console_AddLine("Finished! Operation took: " + FormatTime(stopwatch.ElapsedMilliseconds));

        }
        private void DetectCoresCount(object sender, EventArgs e)
        {
            int detectedCores = Environment.ProcessorCount;

            slider_cores.Value = detectedCores;
            peeker_Cores.Text = detectedCores.ToString();
            cores = detectedCores;

            Console_AddLine($"Detected cores count: {detectedCores}");

            onchange();
        }
        #endregion MAIN

        #region IMAGE FRAMES
        private void inputImageClick(object sender, EventArgs e)
        {
            Console_AddLine("Clicked!");
            if (openImageDialog.ShowDialog() == DialogResult.OK)
            {
                InputPictureBox.Image = Image.FromFile(openImageDialog.FileName);
                InputPicture = new Bitmap(openImageDialog.FileName);

                Console_AddLine("Input image opened!");
                label_Input.Visible = false;
                label_ClickToOpen.Visible = false;
            }
            else
            {
                Console_AddLine("Failed to open input image!");
            }
        }
        private void outputImageClick(object sender, EventArgs e)
        {
            if (OutputPictureBox.Image == null)
            {
                Console_AddLine("No output image to save!");
                return;
            }
            else if (saveImageDialog.ShowDialog() == DialogResult.OK)
            {
                InputPictureBox.Image.Save(saveImageDialog.FileName);
                Console_AddLine("Output image saved as: " + saveImageDialog.FileName);
            }
            else
            {
                Console_AddLine("Failed to save output image!");
            }
        }
        #endregion IMAGE FRAMES

        #region Constant Updates
        private void Slider_Cores_ValueChange(object sender, EventArgs e)
        {
            cores = slider_cores.Value;
            peeker_Cores.Text = cores.ToString();
        }
        private void Slider_MaskBlur_ValueChange(object sender, EventArgs e)
        {
            MaskBlur = slider_MaskBlur.Value;
            peeker_MaskBlur.Text = MaskBlur.ToString() + " px";
        }
        private void Slider_MaskIntensity_ValueChange(object sender, EventArgs e)
        {
            MaskIntensity = slider_MaskIntensity.Value;
            peeker_MaskIntensity.Text = MaskIntensity.ToString() + " %";
        }
        private void Slider_NeonIntensity_ValueChange(object sender, EventArgs e)
        {
            NeonIntensity = slider_NeonIntensity.Value;
            peeker_NeonIntensity.Text = NeonIntensity.ToString() + "%";
        }
        #endregion Constant Updates

        #region Input Updates
        private void Slider_Cores_MouseUp(object sender, MouseEventArgs e)
        {
            cores = slider_cores.Value;
            Console_AddLine("Cores set to: " + cores);

            onchange();
        }
        private void Slider_MaskBlur_MouseUp(object sender, MouseEventArgs e)
        {
            MaskBlur = slider_MaskBlur.Value;
            Console_AddLine("MaskBlur set to: " + MaskBlur);

            onchange();
        }
        private void Slider_MaskIntensity_MouseUp(object sender, MouseEventArgs e)
        {
            MaskIntensity = slider_MaskIntensity.Value;
            Console_AddLine("MaskIntensity set to: " + MaskIntensity);

            onchange();
        }
        private void Slider_NeonIntensity_MouseUp(object sender, MouseEventArgs e)
        {
            NeonIntensity = slider_NeonIntensity.Value;
            Console_AddLine("NeonIntensity set to: " + NeonIntensity);

            onchange();
        }
        private void Select_Library_ValueChanged(object sender, EventArgs e)
        {
            if (select_Library.SelectedIndex == 0)
            {
                library = Library.Assembly;
            }
            else if (select_Library.SelectedIndex == 1)
            {
                library = Library.Cpp;
            }
            else
            {
                library = Library.Unknown;
                Console_AddLine("Unknown Library!");
                return;
            }
            Console_AddLine("\nLibrary set to: " + library);
            onchange();
        }
        private void CheckBox_AutoRun_ValueChanged(object sender, EventArgs e)
        {
            rerun = checkbox_autorun.Checked;
        }
        private void onchange()
        {
            if (this.rerun)
            {
                this.Run(null, null);
            }
        }
        #endregion Slider Updates End

        #region EXTRA FUNCTIONS
        private String FormatTime(long ms)
        {
            if (ms < 1000)
            {
                return ms + "ms";
            }
            else if (ms < 60000)
            {
                return (ms / 1000) + "s";
            }
            else
            {
                return (ms / 60000) + "m";
            }
        }

        private void Console_AddLine(String line)
        {
            Console.AppendText(line + Environment.NewLine);
        }
        private int MinMax(int min, int value, int max)
        {
            return Math.Max(min, Math.Min(value, max));
        }

        #endregion EXTRA FUNCTIONS

        #region ASSEMBLER
        private Bitmap RunAssembly(Bitmap input, int cores, int maskBlur, int maskIntensity, int neonIntensity)
        {
            return input;
        }
        #endregion ASSEMBLER

        #region C++
        private Bitmap RunCpp(Bitmap input, int cores, int maskBlur, int maskIntensity, int neonIntensity)
        {
            if (input == null)
            {
                Console_AddLine("No input image provided!");
                return null;
            }

            int width = input.Width;
            int height = input.Height;

            Bitmap blur = Generate_Blur(input, maskBlur);

            Bitmap neonism = AdjustSaturation(input, neonIntensity);

            Bitmap mask = CalculateMask(input, blur);

            Bitmap result = AdjustWithMask(neonism, mask, maskIntensity);

            // save all new bitmaps

            input.Save("C://users/nimo/Desktop/Neon/input.bmp");
            blur.Save("C://users/nimo/Desktop/Neon/blur.bmp");
            neonism.Save("C://users/nimo/Desktop/Neon/neonism.bmp");
            mask.Save("C://users/nimo/Desktop/Neon/mask.bmp");
            result.Save("C://users/nimo/Desktop/Neon/final_result.bmp");

            Console_AddLine("Saved all images!");


            return result;
        }

        private Bitmap Generate_Blur(Bitmap input, int maskBlur)
        {
            int width = input.Width, height = input.Height;
            Bitmap blur = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color blurredColor = CalculateBlurredColor(input, x, y, maskBlur);
                    blur.SetPixel(x, y, blurredColor);
                }
            };

            return blur;
        }

        private Color CalculateBlurredColor(Bitmap input, int x, int y, int maskBlur)
        {
            int width = input.Width;
            int height = input.Height;

            return Color.FromArgb(1, 2, 3);
        }




        private Bitmap AdjustSaturation(Bitmap input, int neonIntensity)
        {
            if (input == null)
            {
                Console_AddLine("No input image provided for saturation adjustment!");
                return null;
            }

            int width = input.Width;
            int height = input.Height;

            Bitmap adjustedImage = new Bitmap(width, height);

            float saturationFactor = neonIntensity / 100.0f; // Convert to a factor between 1.0 and 2.0

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    adjustedImage.SetPixel(x, y, BumpSaturarionBitmap( input.GetPixel(x, y), neonIntensity));
                }
            }

            return adjustedImage;
        }

        private Color BumpSaturarionBitmap(Color input, int neonIntensity)
        {
            return Color.FromArgb(input.R, input.B, input.G);
        }

        private Bitmap CalculateMask(Bitmap input, Bitmap blur)
        {
            int width = input.Width;
            int height = input.Height;
            Bitmap mask = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int difference = CalculateColorDifference(input.GetPixel(x, y), blur.GetPixel(x, y));

                    mask.SetPixel(x, y, Color.FromArgb(difference, difference, difference));
                }
            }

            return mask;
        }

        private int CalculateColorDifference(Color color1, Color color2)
        {
            return Math.Max(0,Math.Min(255, (Math.Abs(color1.R - color2.R) + Math.Abs(color1.G - color2.G) + Math.Abs(color1.B - color2.B))));
        }

        private Bitmap AdjustWithMask(Bitmap neonism, Bitmap mask, int maskIntensity)
        {
            int width = neonism.Width;
            int height = neonism.Height;
            Bitmap result = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color neonismColor = neonism.GetPixel(x, y);
                    Color maskColor = mask.GetPixel(x, y);

                    int amplifiedMaskIntensity = maskIntensity * maskColor.R / 255;

                    int adjustedR = Math.Min(255, neonismColor.R + amplifiedMaskIntensity);
                    int adjustedG = Math.Min(255, neonismColor.G + amplifiedMaskIntensity);
                    int adjustedB = Math.Min(255, neonismColor.B + amplifiedMaskIntensity);

                    result.SetPixel(x, y, Color.FromArgb(adjustedR, adjustedG, adjustedB));
                }
            }

            return result;
        }
        #endregion C++
    }
}