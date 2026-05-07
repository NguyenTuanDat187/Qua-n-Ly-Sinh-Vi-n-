using OfficeOpenXml;
using QLSinhVien.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace QLSinhVien.Excel
{
    public class ExcelService
    {
        public void ExportToExcel(List<SinhVien> list, string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("SinhVien");

                // Header
                string[] headers = { "Mã SV", "Tên SV", "Giới tính", "Khoa", "Ngành", "Lớp", "Ngày sinh", "Trạng thái", "Học bổng", "Kỷ luật", "Khen thưởng" };
                for (int i = 0; i < headers.Length; i++)
                {
                    ws.Cells[1, i + 1].Value = headers[i];
                    ws.Cells[1, i + 1].Style.Font.Bold = true;
                }

                // Data
                for (int i = 0; i < list.Count; i++)
                {
                    var sv = list[i];
                    ws.Cells[i + 2, 1].Value = sv.MaSV;
                    ws.Cells[i + 2, 2].Value = sv.TenSV;
                    ws.Cells[i + 2, 3].Value = sv.GioiTinh;
                    ws.Cells[i + 2, 4].Value = sv.Khoa;
                    ws.Cells[i + 2, 5].Value = sv.Nganh;
                    ws.Cells[i + 2, 6].Value = sv.Lop;
                    ws.Cells[i + 2, 7].Value = sv.NgaySinh.ToString("dd/MM/yyyy");
                    ws.Cells[i + 2, 8].Value = sv.TrangThai;
                    ws.Cells[i + 2, 9].Value = sv.HocBong;
                    ws.Cells[i + 2, 10].Value = sv.KyLuat;
                    ws.Cells[i + 2, 11].Value = sv.KhenThuong;
                }

                ws.Cells.AutoFitColumns();
                File.WriteAllBytes(filePath, package.GetAsByteArray());
            }
        }
    }
}