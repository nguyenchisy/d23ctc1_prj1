import json
from pathlib import Path


DUONG_DAN_DU_LIEU = Path(__file__).with_name("sinh_vien.json")


def doc_danh_sach_sinh_vien():
	"""Doc danh sach sinh vien tu tep JSON."""
	if not DUONG_DAN_DU_LIEU.exists():
		return []

	try:
		with DUONG_DAN_DU_LIEU.open("r", encoding="utf-8") as tep:
			du_lieu = json.load(tep)
	except (json.JSONDecodeError, OSError):
		return []

	return du_lieu if isinstance(du_lieu, list) else []


def luu_danh_sach_sinh_vien(danh_sach):
	"""Luu danh sach sinh vien vao tep JSON."""
	with DUONG_DAN_DU_LIEU.open("w", encoding="utf-8") as tep:
		json.dump(danh_sach, tep, ensure_ascii=False, indent=2)


def them_sinh_vien():
	"""Nhap va luu mot sinh vien moi."""
	ma_sinh_vien = input("Nhap ma sinh vien: ").strip()
	ho_ten = input("Nhap ho va ten: ").strip()
	ngay_sinh = input("Nhap ngay sinh (DD/MM/YYYY): ").strip()
	lop = input("Nhap lop: ").strip()

	if not all((ma_sinh_vien, ho_ten, ngay_sinh, lop)):
		print("Loi: Khong duoc de trong thong tin sinh vien.")
		return False

	danh_sach = doc_danh_sach_sinh_vien()
	if any(sinh_vien.get("ma_sinh_vien") == ma_sinh_vien for sinh_vien in danh_sach):
		print(f"Loi: Ma sinh vien '{ma_sinh_vien}' da ton tai.")
		return False

	sinh_vien = {
		"ma_sinh_vien": ma_sinh_vien,
		"ho_ten": ho_ten,
		"ngay_sinh": ngay_sinh,
		"lop": lop,
	}
	danh_sach.append(sinh_vien)
	luu_danh_sach_sinh_vien(danh_sach)
	print("Them sinh vien thanh cong.")
	return True


def main():
	"""Hien thi menu quan ly sinh vien."""
	while True:
		print("\n=== QUAN LY SINH VIEN ===")
		print("1. Them sinh vien")
		print("0. Thoat")
		lua_chon = input("Chon chuc nang: ").strip()

		if lua_chon == "1":
			them_sinh_vien()
		elif lua_chon == "0":
			print("Da thoat chuong trinh.")
			break
		else:
			print("Lua chon khong hop le.")


if __name__ == "__main__":
	main()
