# Lập Trình Game

![Logo khoa]("C:\Users\anbin\Downloads\Screenshot 2025-07-17 004120.png")

## Xây Dựng Game Chiến Thuật Lấy Cảm Hứng Từ Địa Đạo Củ Chi

────────────────────────────────────────────

### 1.Cài đặt (Installation)

1. Clone project từ Github: https://github.com/Minh-56/DatThep.git
2. Mở dự án trong Unity:

- Mở Unity Hub, chọn "Add" và trỏ đến thư mục `DatThep`.
- Chọn phiên bản Unity tương thích và mở dự án.

### 2.Hướng dẫn sử dụng (Usage)

1. Bắt đầu trò chơi

- Khởi động game từ **Scene MainMenu**, chọn nút "Bắt đầu" để vào trò chơi.

2. Khu vực chính

- Điều khiển các đơn vị du kích trên bản đồ mặt đất và địa đạo.
- Sử dụng chuột và phím tắt để di chuyển, trang bị vũ khí.

3. Chọn màn chơi

- Chọn các màn chơi đã được mở khóa và bắt đầu chiến đấu.
- mục tiêu là trong thời gian quy định của màn chơi phải tiêu diệt toàn bộ kẻ địch, bảo vệ cửa địa đạo và đảm bảo sự sống còn của quân ta.

4. Kết thúc màn chơi

- Sau mỗi màn, hệ thống hiển thị kết quả (số sao) dựa trên số quân còn lại và hiệu quả chiến đấu.
- Thua cuộc nếu toàn bộ lực lượng bị tiêu diệt, cửa địa đạo bị phát hiện, hoặc hết thời gian quy định.
- Hoàn thành màn để mở khóa màn tiếp theo.

### 3.Mô tả đề tài (Project Description)

1. Tính năng chính (Key Features)

- **Chiến thuật thời gian thực**: Điều khiển đơn vị du kích để tiêu diệt kẻ địch và bảo vệ địa đạo qua 5 màn chơi.
- **Hệ thống chấm sao**: Đánh giá hiệu suất dựa trên số quân còn lại và hiệu quả chiến đấu.
- **Quản lý lực lượng**: Sử dụng địa hình, địa đạo, và chiến thuật như phục kích, rút lui để chiến thắng.

### 4.Công nghệ sử dụng (Technologies Used)

- **Unity**: Phát triển game cho Windows.
- **Thiết kế đồ họa (Graphics Design)**: Krita (phong cách pixel art 2D).

### 5.Nhiệm vụ thành viên (Team Roles)

- **Trần Thành Minh** (Nhóm trưởng):
- Thiết kế sprite các loại quân, quân địch và vũ khí.
- Lập trình điều khiển đơn vị: chọn, di chuyển, chiến đấu.
- Xây dựng hệ thống ô lưới, quản lý bản đồ và thuật toán A\* tìm đường.
- Phát triển kho vũ khí và cơ chế trang bị cho đơn vị.
- Cài đặt camera điều khiển (panning) bằng chuột.
- Xây dựng hệ thống địa đạo: menu cửa, di chuyển nhanh, quân y.

- **Vũ Huy Hoàng**:
- Phát triển hệ thống chọn đơn vị RTS.
- Gán và quản lý nhóm đơn vị, giao diện nhóm.
- Tạo prefab súng và UI kho vũ khí.
- Kết hợp UI nhóm với camera theo dõi đơn vị.
- Xử lý giao diện thông tin đơn vị, tìm và tích hợp âm thanh.

- **Trần Thị Phương Trinh**:
- Tạo Tilemap và bản đồ địa đạo.
- Thiết kế UI nhóm và giao diện MainMenu, GameOver.
- Thêm các loại đạn cho súng, xử lý camera theo dõi unit.
- Lập trình khu chữa trị, xử lý logic thắng–thua cuối trận.

- **Trần Kim Minh**:
- Tối ưu hệ thống điều khiển: ngăn đơn vị chồng vị trí.
- Quản lý thông tin súng và giao diện xem thông tin đơn vị.
- Thiết kế UI: chọn màn, cài đặt, danh mục phím tắt.
- Xử lý chuyển scene giữa mặt đất và địa đạo.
- Tạo UI popup cho cửa địa đạo và logic màn chơi tổng quát.

### 6.Chức năng đã hoàn thiện (Completed Features)

- Hệ thống camera.
- Hệ thống điều khiển các nhân vật, gán nhóm với phím tắt.
- Hệ thống di chuyển giữa 2 khu vực mặt đất và địa đạo
- Hệ thống màn chơi

### 7.Hình ảnh minh họa

- MainMenu:
  ![6]("C:\Users\anbin\Downloads\Screenshot 2025-06-25 111437.png")
- Menu di chuyển nhanh:
  ![7]("C:\Users\anbin\Downloads\Screenshot 2025-07-06 221655.png")
  -Mặt đất:
  ![5]("C:\Users\anbin\Downloads\Screenshot 2025-07-16 234720.png")
  -Địa Đạo:
  ![5]("C:\Users\anbin\Downloads\Screenshot 2025-07-16 234733.png")
  Quân ta:
- Bộ đội
  ![5]("C:\Users\anbin\Downloads\drawing\BoDoi.png")
- Quân y
  ![4]("C:\Users\anbin\Downloads\drawing\NamDuKich-01.png")
- Du kích
  ![3]("C:\Users\anbin\Downloads\drawing\QuanY.png")

  ![2]("C:\Users\anbin\Downloads\drawing\NuDuKich-BaoXe-01.png")

Quân địch

- Bộ binh
  ![1]("C:\Users\anbin\Downloads\drawing\My.png")
