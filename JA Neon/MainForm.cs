#region USING

using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;


enum Library
{
    Assembly, Cpp, Unknown
}

#endregion USING

namespace JA_Neon
{
    public partial class MainForm : Form
    {
        [DllImport(@"C:\Neon\Neonify\x64\Release\JANeonLib.dll")]
        static extern int proc1(int a);

        #region VARIABLES

        private readonly object lockObject = new object();

        private Library library = Library.Assembly;
        private int cores = 8;
        private bool rerun = false;
        private bool lockInterface = false;
        private int MaskBlur = 15;
        private int MaskIntensity = 100;
        private int NeonIntensity = 75;
        private int HueRotate = 0;

        private bool QuickRunAviable = false;

        private Bitmap OutputPicture = null;
        private Bitmap InputPicture = null;
        private Bitmap Cleared = null;
        private Bitmap Blur = null;
        private Bitmap Mask = null;
        private Bitmap Neon = null;

        Color[,] inputPixels;
        Color[,] cleared;
        Color[,] blurPixels;
        Color[,] neonPixels;
        Color[,] maskPixels;

        #endregion VARIABLES

        #region MAIN
        public MainForm()
        {
            InitializeComponent();
        }
        private void Constructor(object sender, EventArgs e)
        {
   /*         Console_AddLine();*/

            slider_cores.Value = cores;
            slider_MaskBlur.Value = MaskBlur;
            slider_MaskIntensity.Value = MaskIntensity;
            slider_NeonIntensity.Value = NeonIntensity;
            slider_Hue.Value = HueRotate;   
            select_Library.SelectedIndex = 1;
            checkbox_autorun.Checked = rerun;
            //checkbox_lockInterface.Checked = lockInterface;

            Console_AddLine("Welcome to Neonify application by nimo! (v0.8.0)");
            Console_AddLine("For more check nimoweb.ddns.net");
        }
        private async void Run(object sender, EventArgs e)
        {
            UpdateProgressBar("Initializing...", 0);

            if (InputPictureBox.Image == null)
            {
                Console_AddLine("No input image selected!");
                return;
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            InputPicture = new Bitmap(InputPictureBox.Image);
            OutputPicture = new Bitmap(InputPicture.Width, InputPicture.Height);
            OutputPictureBox.Image = OutputPicture;

            /* DEBIGGING 
             
            Color[,] inputPixels = new Color[InputPicture.Width, InputPicture.Height];
            for (int x = 0; x < InputPicture.Width; x++)
            {
                for (int y = 0; y < InputPicture.Height; y++)
                {
                    inputPixels[x, y] = InputPicture.GetPixel(x, y);
                }
            }

            for (int i = 0; i <= 100; i++)
            {
                // generate mask for each i and then save to file
                Bitmap blur = new Bitmap(InputPicture.Width, InputPicture.Height);
                Bitmap mask = new Bitmap(InputPicture.Width, InputPicture.Height);

                for (int x = 0; x < InputPicture.Width; x++)
                {
                    for (int y = 0; y < InputPicture.Height; y++)
                    {
                        blur.SetPixel(x, y, CppBlurPx(inputPixels, x, y, i));
                        mask.SetPixel(x, y, CppMaskPx(inputPixels[x, y], blur.GetPixel(x, y), 100));
                        // mask.SetPixel(x, y, CppMaskPx(InputPicture.GetPixel(x, y), CppBlurPx(inputPixels, x, y, i/10), 100));
                    }
                }
                blur.Save(@"C:\Users\nimo\Desktop\Neon\BlurD" + i + ".jpg");
                mask.Save(@"C:\Users\nimo\Desktop\Neon\MaskD" + i + ".jpg");
            }
            */

            UpdateProgressBar("Initializing...", 1);

            try
            {
                if (library == Library.Assembly)
                {
                    UpdateProgressBar("Initializing Assembly...", 0);
                    OutputPicture = await Task.Run(() => RunAssembly(InputPicture, cores, MaskBlur, MaskIntensity, NeonIntensity, HueRotate));
                }
                else if (library == Library.Cpp)
                {
                    UpdateProgressBar("Initializing C++...", 0);
                    OutputPicture = await Task.Run(() => RunCppCode(InputPicture, cores, MaskBlur, MaskIntensity, NeonIntensity, HueRotate));
                }
                else
                {
                    Console_AddLine("Unknown Library!");
                    return;
                }

                UpdateProgressBar("Image Processed!", 1);

                OutputPictureBox.Image = OutputPicture;
                label_Output.Visible = false;
                label_ClickToSave.Visible = false;

                stopwatch.Stop();
                reading_time.Text = FormatTime(stopwatch.ElapsedMilliseconds);
                UpdateProgressBar("Finished!", 1);
                Console_AddLine("Finished! Operation took: " + FormatTime(stopwatch.ElapsedMilliseconds));
            }
            catch (Exception ex)
            {
                Console_AddLine($"An error occurred: {ex.Message}");
                Console_AddLine($"Stack Trace: {ex.StackTrace}");
            }
        }
        private async void QuickRun()
        {
            if (!QuickRunAviable) return;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            UpdateProgressBar("Initializing...", 1);

            try
            {
/*                if (library == Library.Assembly)
                {
                    UpdateProgressBar("Initializing Assembly...", 0);
                    OutputPicture = await Task.Run(() => QuickRunAssembly(InputPicture, cores, MaskBlur, MaskIntensity, NeonIntensity, HueRotate));
                }
                else */
                if (library == Library.Cpp)
                {
                    UpdateProgressBar("Initializing C++...", 0);
                    OutputPicture = await Task.Run(() => QuickRunCppCode(InputPicture, cores, MaskBlur, MaskIntensity, NeonIntensity, HueRotate));
                }
                else
                {
                    Console_AddLine("Unknown Library!");
                    return;
                }

                UpdateProgressBar("Image Processed!", 1);

                OutputPictureBox.Image = OutputPicture;
                label_Output.Visible = false;
                label_ClickToSave.Visible = false;

                stopwatch.Stop();
                reading_time.Text = FormatTime(stopwatch.ElapsedMilliseconds);
                UpdateProgressBar("Finished!", 1);
                Console_AddLine("Finished! Operation took: " + FormatTime(stopwatch.ElapsedMilliseconds));
            }
            catch (Exception ex)
            {
                Console_AddLine($"An error occurred: {ex.Message}");
                Console_AddLine($"Stack Trace: {ex.StackTrace}");
            }
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
        private void button_SaveAllLayers(object sender, EventArgs e)
        {
            if (OutputPicture == null)
            {
                Console_AddLine("Nothing to save!");
                return;
            }

            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = folderBrowserDialog.SelectedPath;

                    SaveImage(InputPicture, folderPath, "Input.png");
                    SaveImage(OutputPicture, folderPath, "Output.png");

                    if (Cleared == null || Neon == null || Blur == null || Mask == null) { return; }

                    SaveImage(Cleared, folderPath, "Cleared.png");
                    SaveImage(Neon, folderPath, "Neon.png");
                    SaveImage(Blur, folderPath, "Blur.png");
                    SaveImage(Mask, folderPath, "Mask.png");
                }
            }
        }
        private void SaveImage(Bitmap image, string folderPath, string fileName)
        {
            if (image != null)
            {
                string filePath = Path.Combine(folderPath, fileName);
                image.Save(filePath);
            }
            else
            {
                Console_AddLine($"{fileName} is null, not saved.");
            }
        }



        #endregion MAIN

        #region IMAGE FRAMES
        private void inputImageClick(object sender, EventArgs e)
        {
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

            saveImageDialog.Filter = "JPEG Image|*.jpg;*.jpeg|PNG Image|*.png|Bitmap Image|*.bmp|GIF Image|*.gif|TIFF Image|*.tiff;*.tif|All Files|*.*";
            saveImageDialog.Title = "Save Image";

            if (saveImageDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveImageDialog.FileName;

                // Get the selected filter index
                int filterIndex = saveImageDialog.FilterIndex;

                // Determine the image format based on the filter index
                ImageFormat imageFormat;

                switch (filterIndex)
                {
                    case 1: // JPEG
                        imageFormat = ImageFormat.Jpeg;
                        break;
                    case 2: // PNG
                        imageFormat = ImageFormat.Png;
                        break;
                    case 3: // Bitmap
                        imageFormat = ImageFormat.Bmp;
                        break;
                    case 4: // GIF
                        imageFormat = ImageFormat.Gif;
                        break;
                    case 5: // TIFF
                        imageFormat = ImageFormat.Tiff;
                        break;
                    default:
                        Console_AddLine("Invalid filter index selected.");
                        return;
                }

                try
                {
                    OutputPictureBox.Image.Save(fileName, imageFormat);
                    Console_AddLine($"Output image saved as: {fileName}");
                }
                catch (Exception ex)
                {
                    Console_AddLine($"Failed to save output image: {ex.Message}");
                    Console_AddLine($"Stack Trace: {ex.StackTrace}");
                }
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
            QuickRunAviable = false;
            cores = slider_cores.Value;
            peeker_Cores.Text = cores.ToString();
        }
        private void Slider_MaskBlur_ValueChange(object sender, EventArgs e)
        {
            QuickRunAviable = false;
            MaskBlur = slider_MaskBlur.Value;
            peeker_MaskBlur.Text = ((double)MaskBlur/10).ToString() + " px";
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
        private void Slider_HueRotate_ValueChange(object sender, EventArgs e)
        {
            HueRotate = slider_Hue.Value;
            peeker_Hue.Text = HueRotate.ToString() + "°";
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
            Console_AddLine("MaskBlur set to: " + ((double)MaskBlur / 10) + " px");

            onchange();
        }
        private void Slider_MaskIntensity_MouseUp(object sender, MouseEventArgs e)
        {
            MaskIntensity = slider_MaskIntensity.Value;
            Console_AddLine("MaskIntensity set to: " + MaskIntensity + " %");
            
            onchange();
        }
        private void Slider_NeonIntensity_MouseUp(object sender, MouseEventArgs e)
        {
            NeonIntensity = slider_NeonIntensity.Value;
            Console_AddLine("NeonIntensity set to: " + NeonIntensity + " %");

            onchange();
        }
        private void Slider_HueRotate_MouseUp(object sender, MouseEventArgs e)
        {
            HueRotate = slider_Hue.Value;
            Console_AddLine("HueRotate set to: " + HueRotate + " %");

            onchange();
        }

        private bool LibSelected = false;
        private void Select_Library_ValueChanged(object sender, EventArgs e)
        {
            QuickRunAviable = false;
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
            if(LibSelected)
                Console_AddLine("\nLibrary set to: " + library);
            else
                LibSelected = true;

            onchange();
        }
        private void CheckBox_AutoRun_ValueChanged(object sender, EventArgs e)
        {
            rerun = checkbox_autorun.Checked;
        }
        private void CheckBox_LockInterface_ValueChanged(object sender, EventArgs e)
        {
            //lockInterface = checkbox_lockInterface.Checked;
        }
        private void onchange()
        {
            if (this.rerun)
            {
                this.Run(null, null);
            } else if (QuickRunAviable)
            {
                this.QuickRun();
            }
        }
        #endregion Slider Updates End

        #region EXTRA FUNCTIONS
        private String FormatTime(long ms)
        {
            String s = "";

            if(ms > 60000)
            {
                s += (ms / 60000) + "m ";
            }
            if (ms > 1000)
            {
                s += (ms % 60000) / 1000 + "s ";
            }

            s += (ms % 1000) + "ms";

            return s;
        }
        private void Console_AddLine(String line)
        {
            Console.AppendText(line + Environment.NewLine);
        }
        private int MinMax(int min, int value, int max)
        {
            return Math.Max(min, Math.Min(value, max));
        }
        private void UpdateProgressBar(string s, double percentage)
        {
            int value = (int)(percentage * 100);

            if (ProgressBar.InvokeRequired)
            {
                ProgressBar.Invoke(new Action(() =>
                {
                    label_ProgressBar.Text = $"{s} {value}%";
                    ProgressBar.Value = value;
                }));
            }
            else
            {
                label_ProgressBar.Text = $"{s} {value}%";
                ProgressBar.Value = value;
            }
        }



        #endregion EXTRA FUNCTIONS

        #region ASSEMBLER
        private async Task<Bitmap> RunAssembly(Bitmap inputPicture, int cores, int maskBlur, int maskIntensity, int neonIntensity, int hueRotate)
        {
            int width = inputPicture.Width, height = inputPicture.Height;
            int[] vectorizedImage = new int[width * height * 3];
            int progress = 0, todo = width * height, batchSize = 1000;

            await Task.Run(() =>
            {
                Parallel.For(0, width, new ParallelOptions { MaxDegreeOfParallelism = cores }, x =>
                {
                    for (int y = 0; y < height; y++)
                    {
                        int baseIndex = width * x + 3 * y;
                        Color pixel = inputPicture.GetPixel(x, y);

                        vectorizedImage[baseIndex] = pixel.R;
                        vectorizedImage[baseIndex + 1] = pixel.G;
                        vectorizedImage[baseIndex + 2] = pixel.B;
                    }

                    lock (lockObject)
                    {
                        if (!lockInterface && progress++ % batchSize == 0)
                        {
                            UpdateProgressBar("Linearizing", (double)progress / todo);
                        }
                    }
                });
            });

            UpdateProgressBar("Running ASM", 0);
            // int[] rgb;
/*            int[] rgb = AsmInterop.NeonifyASM(vectorizedImage, width, height, maskBlur, maskIntensity, neonIntensity, hueRotate);*/
            UpdateProgressBar("Running ASM", 1);

            progress = 0;
            await Task.Run(() =>
            {
                Parallel.For(0, width, new ParallelOptions { MaxDegreeOfParallelism = cores }, x =>
                {
                    for (int y = 0; y < height; y++)
                    {
                        int baseIndex = width * x + 3 * y;
                       /* OutputPicture.SetPixel(x, y, Color.FromArgb(rgb[baseIndex], rgb[baseIndex + 1], rgb[baseIndex + 2]));*/
                    }

                    lock (lockObject)
                    {
                        if (!lockInterface && progress++ % batchSize == 0)
                        {
                            UpdateProgressBar("Unlinearizing", (double)progress / todo);
                        }
                    }
                });
            });

            return OutputPicture;
        }

        #endregion ASSEMBLER

        #region C++
        private async Task<Bitmap> RunCppCode(Bitmap inputPicture, int cores, int maskBlur, int maskIntensity, int neonIntensity, int hueRotate)
        {
            UpdateProgressBar("Initializing C++", 0);

            int width = inputPicture.Width;
            int height = inputPicture.Height;

            OutputPicture = new Bitmap(width, height);
            Cleared = new Bitmap(width, height);
            Blur = new Bitmap(width, height);
            Mask = new Bitmap(width, height);
            Neon = new Bitmap(width, height);

            inputPixels = new Color[width, height];
            cleared = new Color[width, height];
            blurPixels = new Color[width, height];
            neonPixels = new Color[width, height];
            maskPixels = new Color[width, height];

            int progress = 0, todo = (width * height), batchSize = 1000, lastProgress = 0;


            UpdateProgressBar("Initializing C++", 0);
            await Task.Run(() =>
            {
                Parallel.For(0, width, new ParallelOptions { MaxDegreeOfParallelism = cores }, x =>
                {
                    for (int y = 0; y < height; y++)
                    {
                        lock (lockObject)
                        {
                            inputPixels[x, y] = inputPicture.GetPixel(x, y);
                        }

                        if (!lockInterface && progress++ % batchSize == 0)
                        {
                            UpdateProgressBar("Initializing C++", (double)progress / todo);
                        }
                    }
                });
            });
            UpdateProgressBar("Initializing C++", 1);

            progress = 0;

            double madkBlurSQRT = Math.Sqrt(maskBlur * 10);

            UpdateProgressBar("Preparing Image", 0);
            await Task.Run(() =>
            {
                Parallel.For(0, width, new ParallelOptions { MaxDegreeOfParallelism = cores }, x =>
                {
                    for (int y = 0; y < height; y++)
                    {
                        lock (lockObject)
                        {
                            cleared[x, y] = CppBlurPx(inputPixels, x, y, madkBlurSQRT);
                            Cleared.SetPixel(x, y, cleared[x, y]);
                        }

                        if (!lockInterface && progress++ % batchSize == 0)
                        {
                            int currentProgress = (int)((double)progress / todo * 100);
                            if (currentProgress != lastProgress)
                            {
                                lastProgress = currentProgress;
                                UpdateProgressBar("Preparing Image", (double)progress / todo);
                            }
                        }
                    }
                });
            });
            UpdateProgressBar("Preparing Image", 1);

            progress = 0;

            await Task.Run(() =>
            {
                Parallel.For(0, width, new ParallelOptions { MaxDegreeOfParallelism = cores }, x =>
                {
                    for (int y = 0; y < height; y++)
                    {
                        lock (lockObject)
                        {
                            neonPixels[x, y] = CppNeonPx(cleared[x, y], neonIntensity, hueRotate);
                            blurPixels[x, y] = CppBlurPx(cleared, x, y, maskBlur);
                            maskPixels[x, y] = CppMaskPx(cleared[x, y], blurPixels[x, y], maskIntensity);

                            OutputPicture.SetPixel(x, y, CppMixPx(cleared[x, y], neonPixels[x, y], maskPixels[x, y]));

                            Neon.SetPixel(x, y, neonPixels[x, y]);
                            Blur.SetPixel(x, y, blurPixels[x, y]);
                            Mask.SetPixel(x, y, maskPixels[x, y]);
                        }

                        if (!lockInterface && progress++ % batchSize == 0)
                        {
                            int currentProgress = (int)((double)progress / todo * 100);
                            if (currentProgress != lastProgress)
                            {
                                lastProgress = currentProgress;
                                UpdateProgressBar("Processing Image", (double)progress / todo);
                            }
                        }
                    }
                });
            });


            QuickRunAviable = true;

            return OutputPicture;
        }

        private async Task<Bitmap> QuickRunCppCode(Bitmap inputPicture, int cores, int maskBlur, int maskIntensity, int neonIntensity, int hueRotate)
        {
            UpdateProgressBar("Initializing C++", 0);

            int width = inputPicture.Width;
            int height = inputPicture.Height;

            Bitmap OutputPicture = new Bitmap(width, height);
            Bitmap Blur = new Bitmap(width, height);
            Bitmap Mask = new Bitmap(width, height);
            Bitmap Neon = new Bitmap(width, height);

            int progress = 0, todo = (width * height), batchSize = 1000, lastProgress = 0;

            double madkBlurSQRT = Math.Sqrt(maskBlur * 10);

            progress = 0;

            await Task.Run(() =>
            {
                Parallel.For(0, width, new ParallelOptions { MaxDegreeOfParallelism = cores }, x =>
                {
                    for (int y = 0; y < height; y++)
                    {
                        lock (lockObject)
                        {
                            neonPixels[x, y] = CppNeonPx(cleared[x, y], neonIntensity, hueRotate);
                            maskPixels[x, y] = CppMaskPx(cleared[x, y], blurPixels[x, y], maskIntensity);

                            OutputPicture.SetPixel(x, y, CppMixPx(cleared[x, y], neonPixels[x, y], maskPixels[x, y]));

                            Neon.SetPixel(x, y, neonPixels[x, y]);
                            Mask.SetPixel(x, y, maskPixels[x, y]);
                        }

                        if (!lockInterface && progress++ % batchSize == 0)
                        {
                            int currentProgress = (int)((double)progress / todo * 100);
                            if (currentProgress != lastProgress)
                            {
                                lastProgress = currentProgress;
                                UpdateProgressBar("Refreshing the Image", (double)progress / todo);
                            }
                        }
                    }
                });
            });

            return OutputPicture;
        }

        private Color CppBlurPx(Color[,] pixels, int x, int y, double maskBlur)
        {
            double r = 0, g = 0, b = 0;
            double w = 0;
            double radious = (double)maskBlur / 10;

            for (int i = (int)((double)x - radious); i <= (int)(x + radious); i++)
            {
                for(int j = (int)((double)y - radious); j <= (int)(y + radious); j++)
                {
                    if (i >= 0 && i < pixels.GetLength(0) && j >= 0 && j < pixels.GetLength(1))
                    {
                        double weigth = Math.Max(0, (radious - Math.Sqrt(Math.Pow(x - i, 2) + Math.Pow(y - j, 2))));

                        r += pixels[i, j].R * weigth;
                        g += pixels[i, j].G * weigth;
                        b += pixels[i, j].B * weigth;

                        w += weigth;
                    }
                }
            }

            if (w == 0)
            {
                return Color.FromArgb(0, 0, 0);
            }

            r /= w;
            g /= w;
            b /= w;

            return Color.FromArgb(
                MinMax(0, (int)r, 255),
                MinMax(0, (int)g, 255),
                MinMax(0, (int)b, 255)
            );
        }

        private Color CppNeonPx(Color px, int neonIntensity, int hueRotate)
        {
            return FromHVS_neon(px.GetHue(), 1, 1, neonIntensity, hueRotate);
        }

        private Color CppMaskPx(Color px, Color blur, int maskIntensity)
        {
            return Color.FromArgb(
                MinMax(0, (Math.Abs(px.R - blur.R) * (maskIntensity) - 10) / 20, 255),
                MinMax(0, (Math.Abs(px.R - blur.R) * (maskIntensity) - 10) / 20, 255),
                MinMax(0, (Math.Abs(px.R - blur.R) * (maskIntensity) - 10) / 20, 255)
                );
        }

        private Color CppMixPx(Color px, Color neon, Color mask)
        {
            return Color.FromArgb(
                 MinMax(0, px.R * (255 - mask.R) / 255 + neon.R * (mask.R) / 255, 255),
                 MinMax(0, px.G * (255 - mask.G) / 255 + neon.G * (mask.G) / 255, 255),
                 MinMax(0, px.B * (255 - mask.B) / 255 + neon.B * (mask.B) / 255, 255)
                );
        }

        private Color FromHVS(float H, float S, float V)
        {
    
            float hue = H / 360.0f;

            if (S == 0)
            {
                int grayValue = (int)(V * 255);
                return Color.FromArgb(grayValue, grayValue, grayValue);
            }

            float h = 6 * hue;
            int i = (int)h;
            float f = h - i;

            float p = V * (1 - S);
            float q = V * (1 - f * S);
            float t = V * (1 - (1 - f) * S);

            float[] components = new float[] { V, q, p, p, t, V };

            int r = (int)(components[i % 6] * 255);
            int g = (int)(components[(i + 4) % 6] * 255);
            int b = (int)(components[(i + 2) % 6] * 255);

            return Color.FromArgb(r, g, b);
        }
        private Color FromHVS_neon(float H, float S, float V, int neonIntensity, int hueRotate)
        {
            float hue = (H + hueRotate + 360)%360 / 360.0f;

            S = Math.Min(S * (neonIntensity) / 100, 1);

            if (S == 0)
            {
                int grayValue = (int)(V * 255);
                return Color.FromArgb(grayValue, grayValue, grayValue);
            }

            float h = 6 * hue;
            int i = (int)h;
            float f = h - i;

            float p = V * (1 - S);
            float q = V * (1 - f * S);
            float t = V * (1 - (1 - f) * S);

            float[] components = new float[] { V, q, p, p, t, V };

            int r = (int)(components[i % 6] * 255);
            int g = (int)(components[(i + 4) % 6] * 255);
            int b = (int)(components[(i + 2) % 6] * 255);

            return Color.FromArgb(r, g, b);
        }

        #endregion C++


    }
}