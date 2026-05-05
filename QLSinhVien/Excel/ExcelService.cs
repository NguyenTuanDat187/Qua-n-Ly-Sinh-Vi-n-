using OfficeOpenXml;
using QLSinhVien.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace QLSinhVien.Excel
{
    public class ExcelService
    {
        private string filePath = "sinhvien.xlsx";

        public void Save(List<SinhVien> list)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("SinhVien");

                // 🔥 Header
                string[] headers = {
                    "MaSV","TenSV","GioiTinh","Khoa","Nganh",
                    "Lop","NgaySinh","TrangThai","HocBong","KyLuat"
                };

                for (int i = 0; i < headers.Length; i++)
                {
                    ws.Cells[1, i + 1].Value = headers[i];
                    ws.Cells[1, i + 1].Style.Font.Bold = true;
                }

                // 🔥 Data
                for (int i = 0; i < list.Count; i++)
                {
                    var sv = list[i];
                    ws.Cells[i + 2, 1].Value = sv.MaSV;
                    ws.Cells[i + 2, 2].Value = sv.TenSV;
                    ws.Cells[i + 2, 3].Value = sv.GioiTinh;
                    ws.Cells[i + 2, 4].Value = sv.Khoa;
                    ws.Cells[i + 2, 5].Value = sv.Nganh;
                    ws.Cells[i + 2, 6].Value = sv.Lop;
                    ws.Cells[i + 2, 7].Value = sv.NgaySinh;
                    ws.Cells[i + 2, 7].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[i + 2, 8].Value = sv.TrangThai;
                    ws.Cells[i + 2, 9].Value = sv.HocBong;
                    ws.Cells[i + 2, 10].Value = sv.KyLuat;
                }

                // 🔥 Auto fit đẹp
                ws.Cells.AutoFitColumns();

                File.WriteAllBytes(filePath, package.GetAsByteArray());
            }
        }

        public List<SinhVien> Load()
        {
            var list = new List<SinhVien>();

            if (!File.Exists(filePath)) return list;

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var ws = package.Workbook.Worksheets[0];

                if (ws.Dimension == null) return list;

                int rowCount = ws.Dimension.Rows;

                for (int i = 2; i <= rowCount; i++)
                {
                    DateTime.TryParse(ws.Cells[i, 7].Text, out DateTime ngaySinh);

                    list.Add(new SinhVien
                    {
                        MaSV = ws.Cells[i, 1].Text,
                        TenSV = ws.Cells[i, 2].Text,
                        GioiTinh = ws.Cells[i, 3].Text,
                        Khoa = ws.Cells[i, 4].Text,
                        Nganh = ws.Cells[i, 5].Text,
                        Lop = ws.Cells[i, 6].Text,
                        NgaySinh = ngaySinh,
                        TrangThai = ws.Cells[i, 8].Text,
                        HocBong = ws.Cells[i, 9].Text,
                        KyLuat = ws.Cells[i, 10].Text
                    });
                }
            }

            return list;
        }
    }
}