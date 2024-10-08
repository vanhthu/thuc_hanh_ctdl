﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.IO;
namespace C1_Bai2
{
    internal class Program
    {
        static void TinhThoiGianChoTungCachChay()
        {

        }
        static void NhapTuBanPhim()
        {            
            Console.Write("\n\nNhap vao so luong sinh vien: ");
            int n = Convert.ToInt32(Console.ReadLine());
            SinhVien[] dssv = new SinhVien[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhap ma sinh vien: ");
                string maSV = Console.ReadLine();
                Console.Write("Nhap diem mon 1: ");
                int mon1= Convert.ToInt32(Console.ReadLine());
                Console.Write("Nhap diem mon 2: ");
                int mon2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Nhap diem mon 3: ");
                int mon3 = Convert.ToInt32(Console.ReadLine());

                dssv[i] = new SinhVien(maSV, mon1, mon2, mon3);
            }

            Stopwatch timer = new Stopwatch();
            timer.Start();
            double dtbCach1 = QLSV.DiemTrungBinhMon(dssv);
            timer.Stop();

            
            Console.WriteLine($"Diem trung binh theo cach 1: {dtbCach1}");
            Console.WriteLine($"Thoi gian tinh diem trung binh theo cach 1: {timer.ElapsedMilliseconds} ms");

            timer.Start();
            double dtbCach2 = QLSV.DiemTrungBinhMonSV(dssv);
            timer.Stop();

            Console.WriteLine($"Diem trung binh theo cach 1: {dtbCach2}");
            Console.WriteLine($"Thoi gian tinh diem trung binh theo cach 2: {timer.ElapsedMilliseconds} ms");


        }

        static SinhVien[] NhapDuLieuNgauNhien()
        {            
            Random random = new Random();
            Console.Write("\n\nNhap vao so luong sinh vien: ");
            int n = Convert.ToInt32(Console.ReadLine());
            SinhVien[] dssv = new SinhVien[n];

            for (int i = 0; i < n; i++)
            {
                string maSV = $"Ma sinh vien: {i + 1}";
                Console.WriteLine(maSV);

                int mon1 = random.Next(0, 101); // random từ 0-100
                Console.WriteLine($"Diem mon 1: {mon1}");

                int mon2 = random.Next(0, 101);
                Console.WriteLine($"Diem mon 2: {mon2}");


                int mon3 = random.Next(0, 101);
                Console.WriteLine($"Diem mon 3: {mon3}");


                dssv[i] = new SinhVien(maSV, mon1, mon2, mon3);
            }
            Stopwatch timer = new Stopwatch();
            timer.Start();
            double dtbCach1 = QLSV.DiemTrungBinhMon(dssv);
            timer.Stop();


            Console.WriteLine($"Diem trung binh theo cach 1: {dtbCach1}");
            Console.WriteLine($"Thoi gian tinh diem trung binh theo cach 1: {timer.ElapsedMilliseconds} ms");

            timer.Start();
            double dtbCach2 = QLSV.DiemTrungBinhMonSV(dssv);
            timer.Stop();

            Console.WriteLine($"Diem trung binh theo cach 1: {dtbCach2}");
            Console.WriteLine($"Thoi gian tinh diem trung binh theo cach 2: {timer.ElapsedMilliseconds} ms");
            return dssv;
        }


        static SinhVien[] NhapSinhVienKhoiTaoGiaTri()
        {
            Random random = new Random();
            Console.Write("\n\nNhap vao so luong sinh vien: ");
            int n = Convert.ToInt32(Console.ReadLine());
            SinhVien[] dssv = new SinhVien[n];

            for (int i = 0;i<n; i++)
            {
                string maSV = $"*Ma sinh vien: {i + 1}";
                Console.WriteLine(maSV);

                int mon1 = 50 + i % 50; // random từ 0-100
                Console.WriteLine($"\t- Diem mon 1: {mon1}");

                int mon2 = 60 + i % 40;
                Console.WriteLine($"\t- Diem mon 2: {mon2}");


                int mon3 = 70 + i % 30;
                Console.WriteLine($"\t- Diem mon 3: {mon3}");


                dssv[i] = new SinhVien(maSV, mon1, mon2, mon3);
            }

            Stopwatch timer = new Stopwatch();
            timer.Start();
            double dtbCach1 = QLSV.DiemTrungBinhMon(dssv);
            timer.Stop();


            Console.WriteLine($"Diem trung binh theo cach 1: {dtbCach1}");
            Console.WriteLine($"Thoi gian tinh diem trung binh theo cach 1: {timer.ElapsedMilliseconds} ms");

            timer.Start();
            double dtbCach2 = QLSV.DiemTrungBinhMonSV(dssv);
            timer.Stop();

            Console.WriteLine($"Diem trung binh theo cach 1: {dtbCach2}");
            Console.WriteLine($"Thoi gian tinh diem trung binh theo cach 2: {timer.ElapsedMilliseconds} ms");
            return dssv;
        }


        static SinhVien[] DocFileText(string filePath)
        {
            int numOfStudents = File.ReadAllLines(filePath).Length - 1;
            SinhVien[] dssv = new SinhVien[numOfStudents];

            StreamReader streamReader = new StreamReader(filePath);
            string line;
            string[] fields;

            line = streamReader.ReadLine(); //header
            int i = 0;         

            while ((line = streamReader.ReadLine()) != null)
            {
                fields = line.Split(',');
                dssv[i] = new SinhVien();
                dssv[i].masv = fields[0];
                dssv[i].mon1 = Convert.ToInt32(fields[1]);
                dssv[i].mon2 = Convert.ToInt32(fields[2]);                
                dssv[i].mon3 = Convert.ToInt32(fields[3]);
                dssv[i].DiemTrungBinh();
                i++;
            }
            streamReader.Close();
            double diemTrungBinh = 0;
            
            //foreach (SinhVien sv in dssv)
            //{
            //    diemTrungBinh += sv.DiemTrungBinh();
            //}
            //diemTrungBinh /= numOfStudents;

            //Console.WriteLine($"Tong diem trung binh: {diemTrungBinh}");



            // cach 2
            foreach(SinhVien sv in dssv)
            {
                double tongDiemTrungBinh1 = sv.DiemTrungBinh();
                Console.WriteLine($"MSSV: {sv.masv} - M1: {sv.mon1} - M2: {sv.mon2} - M3: {sv.mon3} - Diem TB: {tongDiemTrungBinh1}");
                diemTrungBinh += tongDiemTrungBinh1;
            }

            return dssv;
        }


        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("************** MENU **************************");
                Console.WriteLine("*    1. Nhap tu ban phim                     *");
                Console.WriteLine("*    2. Nhap so luong ngau nhien             *");
                Console.WriteLine("*    3. Nhap sinh vien khoi tao gia tri      *");
                Console.WriteLine("*    4. Doc du lieu tu file text             *");
                Console.WriteLine("**********************************************");

                Console.Write("Lua chon cua ban la: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice) {
                    case 1: NhapTuBanPhim(); break;
                    case 2: NhapDuLieuNgauNhien(); break;
                    case 3: NhapSinhVienKhoiTaoGiaTri(); break;
                    case 4: 
                        DocFileText("E:\\University\\the_last_one\\data_structure\\thuc_hanh_ctdl\\C1_Bai2\\sample_data\\sample_data1.txt"); 
                        break;
                    case 0:
                        Console.WriteLine("Ban muon thoat khoi chuong trinh?");                        
                        break;
                    default: 
                        Console.WriteLine("Du lieu khong hop le!");
                        break;
                }
                Console.WriteLine("\nNhap phim bat ky de tiep tuc!");
                Console.ReadKey();
                Console.Clear();
            }
            while (choice != 0);
        }
    }
}
