using QuanLyBanDoChoi.BUS;
using QuanLyBanDoChoi.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanDoChoi.GUI
{
    public partial class frmLoc : Form
    {
        public FilterModel FilterData { get; private set; }

        public frmLoc(FilterModel currentFilter = null, IEnumerable<string> dsThuongHieu = null, IEnumerable<string> dsDoTuoi = null)
        {
            InitializeComponent();
            FilterData = currentFilter != null ? currentFilter.Clone() : new FilterModel();
            InitDataControls(dsThuongHieu, dsDoTuoi);
            LoadCurrentFilter();
        }

        private void InitDataControls(IEnumerable<string> dsThuongHieu = null, IEnumerable<string> dsDoTuoi = null)
        {
            // Danh sách thương hiệu
            cboThuongHieu.Items.Clear();
            cboThuongHieu.Items.Add("Tất cả");
            var setThuongHieu = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "Miniso", "Lego", "Barbie", "Hot Wheels", "Bandai", "Fisher-Price"
            };
            if (dsThuongHieu != null)
            {
                foreach (var th in dsThuongHieu)
                {
                    if (!string.IsNullOrWhiteSpace(th))
                        setThuongHieu.Add(th.Trim());
                }
            }
            foreach (var th in setThuongHieu)
            {
                cboThuongHieu.Items.Add(th);
            }

            // Danh sách độ tuổi
            cboDoTuoi.Items.Clear();
            cboDoTuoi.Items.Add("Tất cả");
            var setDoTuoi = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "0-3 tuổi", "3-6 tuổi", "6-12 tuổi", "Trên 12 tuổi"
            };
            if (dsDoTuoi != null)
            {
                foreach (var dt in dsDoTuoi)
                {
                    if (!string.IsNullOrWhiteSpace(dt))
                        setDoTuoi.Add(dt.Trim());
                }
            }
            foreach (var dt in setDoTuoi)
            {
                cboDoTuoi.Items.Add(dt);
            }

            // Sắp xếp
            cboSapXep.Items.Clear();
            cboSapXep.Items.AddRange(new object[] { "Mới nhất", "Tên A-Z", "Giá tăng dần", "Giá giảm dần", "Tồn kho thấp", "Bán chạy nhất" });
        }

        private void LoadCurrentFilter()
        {
            if (FilterData == null) FilterData = new FilterModel();

            // Trạng thái tồn kho
            switch (FilterData.TrangThaiTonKho)
            {
                case "Còn hàng": rdoConHang.Checked = true; break;
                case "Sắp hết": rdoSapHet.Checked = true; break;
                case "Hết hàng": rdoHetHang.Checked = true; break;
                default: rdoTonKhoTatCa.Checked = true; break;
            }

            // Khoảng giá
            txtGiaTu.Text = FilterData.GiaTu.HasValue ? FilterData.GiaTu.Value.ToString("0.##") : "";
            txtGiaDen.Text = FilterData.GiaDen.HasValue ? FilterData.GiaDen.Value.ToString("0.##") : "";

            // Số lượng tồn
            txtTonKhoTu.Text = FilterData.TonKhoTu.HasValue ? FilterData.TonKhoTu.Value.ToString() : "";
            txtTonKhoDen.Text = FilterData.TonKhoDen.HasValue ? FilterData.TonKhoDen.Value.ToString() : "";

            // Thương hiệu
            int idxTH = cboThuongHieu.FindStringExact(FilterData.ThuongHieu ?? "Tất cả");
            cboThuongHieu.SelectedIndex = idxTH >= 0 ? idxTH : 0;

            // Độ tuổi
            int idxDT = cboDoTuoi.FindStringExact(FilterData.DoTuoi ?? "Tất cả");
            cboDoTuoi.SelectedIndex = idxDT >= 0 ? idxDT : 0;

            // Kênh bán
            chkShopee.Checked = FilterData.KenhBan != null && FilterData.KenhBan.Contains("Shopee");
            chkTikTok.Checked = FilterData.KenhBan != null && FilterData.KenhBan.Contains("TikTok Shop");
            chkLazada.Checked = FilterData.KenhBan != null && FilterData.KenhBan.Contains("Lazada");
           

            // Trạng thái đồng bộ
            switch (FilterData.TrangThaiDongBo)
            {
                case "Đồng bộ OK": rdoDongBoOK.Checked = true; break;
                case "Lỗi đồng bộ": rdoLoiDongBo.Checked = true; break;
                default: rdoDongBoTatCa.Checked = true; break;
            }

            // Sắp xếp
            int idxSX = cboSapXep.FindStringExact(FilterData.SapXepTheo ?? "Mới nhất");
            cboSapXep.SelectedIndex = idxSX >= 0 ? idxSX : 0;
        }

        private void btnApDung_Click(object sender, EventArgs e)
        {
            // 1. Trạng thái tồn kho
            if (rdoConHang.Checked) FilterData.TrangThaiTonKho = "Còn hàng";
            else if (rdoSapHet.Checked) FilterData.TrangThaiTonKho = "Sắp hết";
            else if (rdoHetHang.Checked) FilterData.TrangThaiTonKho = "Hết hàng";
            else FilterData.TrangThaiTonKho = "Tất cả";

            // 2. Khoảng giá (Giá từ - Giá đến)
            decimal? giaTu = null;
            if (!string.IsNullOrWhiteSpace(txtGiaTu.Text))
            {
                if (decimal.TryParse(txtGiaTu.Text.Trim().Replace(",", ""), out decimal valGiaTu))
                {
                    giaTu = valGiaTu;
                }
                else
                {
                    MessageBox.Show("Giá từ không hợp lệ! Vui lòng nhập số.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGiaTu.Focus();
                    return;
                }
            }

            decimal? giaDen = null;
            if (!string.IsNullOrWhiteSpace(txtGiaDen.Text))
            {
                if (decimal.TryParse(txtGiaDen.Text.Trim().Replace(",", ""), out decimal valGiaDen))
                {
                    giaDen = valGiaDen;
                }
                else
                {
                    MessageBox.Show("Giá đến không hợp lệ! Vui lòng nhập số.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGiaDen.Focus();
                    return;
                }
            }

            if (giaTu.HasValue && giaDen.HasValue && giaTu.Value > giaDen.Value)
            {
                MessageBox.Show("Khoảng giá không hợp lệ: 'Giá từ' không được lớn hơn 'Giá đến'!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaTu.Focus();
                return;
            }

            FilterData.GiaTu = giaTu;
            FilterData.GiaDen = giaDen;

            // 3. Số lượng tồn (Từ - Đến)
            int? tonTu = null;
            if (!string.IsNullOrWhiteSpace(txtTonKhoTu.Text))
            {
                if (int.TryParse(txtTonKhoTu.Text.Trim(), out int valTonTu))
                {
                    tonTu = valTonTu;
                }
                else
                {
                    MessageBox.Show("Số lượng tồn 'Từ' không hợp lệ! Vui lòng nhập số nguyên.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTonKhoTu.Focus();
                    return;
                }
            }

            int? tonDen = null;
            if (!string.IsNullOrWhiteSpace(txtTonKhoDen.Text))
            {
                if (int.TryParse(txtTonKhoDen.Text.Trim(), out int valTonDen))
                {
                    tonDen = valTonDen;
                }
                else
                {
                    MessageBox.Show("Số lượng tồn 'Đến' không hợp lệ! Vui lòng nhập số nguyên.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTonKhoDen.Focus();
                    return;
                }
            }

            if (tonTu.HasValue && tonDen.HasValue && tonTu.Value > tonDen.Value)
            {
                MessageBox.Show("Số lượng tồn không hợp lệ: Số lượng 'Từ' không được lớn hơn 'Đến'!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTonKhoTu.Focus();
                return;
            }

            FilterData.TonKhoTu = tonTu;
            FilterData.TonKhoDen = tonDen;

            // 4. Thương hiệu (ComboBox)
            FilterData.ThuongHieu = cboThuongHieu.SelectedItem?.ToString() ?? "Tất cả";

            // 5. Độ tuổi (ComboBox)
            FilterData.DoTuoi = cboDoTuoi.SelectedItem?.ToString() ?? "Tất cả";

            // 6. Kênh bán
            FilterData.KenhBan = new List<string>();
            if (chkShopee.Checked) FilterData.KenhBan.Add("Shopee");
            if (chkTikTok.Checked) FilterData.KenhBan.Add("TikTok Shop");
            if (chkLazada.Checked) FilterData.KenhBan.Add("Lazada");
           
            // 7. Trạng thái đồng bộ
            if (rdoDongBoOK.Checked) FilterData.TrangThaiDongBo = "Đồng bộ OK";
            else if (rdoLoiDongBo.Checked) FilterData.TrangThaiDongBo = "Lỗi đồng bộ";
            else FilterData.TrangThaiDongBo = "Tất cả";

            // 8. Sắp xếp
            FilterData.SapXepTheo = cboSapXep.SelectedItem?.ToString() ?? "Mới nhất";

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnXoaBoLoc_Click(object sender, EventArgs e)
        {
            // Đưa toàn bộ tham số lọc về mặc định
            FilterData = new FilterModel();
            LoadCurrentFilter();

            // Đóng form với kết quả OK để màn hình chính tải lại toàn bộ danh sách
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }

    public class FilterModel
    {
        public string TrangThaiTonKho { get; set; } = "Tất cả";
        public decimal? GiaTu { get; set; }
        public decimal? GiaDen { get; set; }
        public int? TonKhoTu { get; set; }
        public int? TonKhoDen { get; set; }
        public string ThuongHieu { get; set; } = "Tất cả";
        public string DoTuoi { get; set; } = "Tất cả";
        public List<string> KenhBan { get; set; } = new List<string>();
        public string TrangThaiDongBo { get; set; } = "Tất cả";
        public string SapXepTheo { get; set; } = "Mới nhất";

        public FilterModel Clone()
        {
            return new FilterModel
            {
                TrangThaiTonKho = this.TrangThaiTonKho,
                GiaTu = this.GiaTu,
                GiaDen = this.GiaDen,
                TonKhoTu = this.TonKhoTu,
                TonKhoDen = this.TonKhoDen,
                ThuongHieu = this.ThuongHieu,
                DoTuoi = this.DoTuoi,
                KenhBan = new List<string>(this.KenhBan ?? new List<string>()),
                TrangThaiDongBo = this.TrangThaiDongBo,
                SapXepTheo = this.SapXepTheo
            };
        }

        public bool IsDefault()
        {
            return (TrangThaiTonKho == "Tất cả" || string.IsNullOrEmpty(TrangThaiTonKho))
                && !GiaTu.HasValue
                && !GiaDen.HasValue
                && !TonKhoTu.HasValue
                && !TonKhoDen.HasValue
                && (ThuongHieu == "Tất cả" || string.IsNullOrEmpty(ThuongHieu))
                && (DoTuoi == "Tất cả" || string.IsNullOrEmpty(DoTuoi))
                && (KenhBan == null || KenhBan.Count == 0)
                && (TrangThaiDongBo == "Tất cả" || string.IsNullOrEmpty(TrangThaiDongBo))
                && (SapXepTheo == "Mới nhất" || string.IsNullOrEmpty(SapXepTheo));
        }
    }
}
