# Lập Trình Game

<img width="904" height="153" alt="Screenshot 2025-07-17 004120" src="https://github.com/user-attachments/assets/8171ef24-dffd-4a2d-ac77-58a4bf81a319" />

## Xây Dựng Game Chiến Thuật Lấy Cảm Hứng Từ Địa Đạo Củ Chi

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

**Trần Thành Minh** (Nhóm trưởng):
- Thiết kế sprite các loại quân, quân địch và vũ khí.
- Lập trình điều khiển đơn vị: chọn, di chuyển, chiến đấu.
- Xây dựng hệ thống ô lưới, quản lý bản đồ và thuật toán A\* tìm đường.
- Phát triển kho vũ khí và cơ chế trang bị cho đơn vị.
- Cài đặt camera điều khiển (panning) bằng chuột.
- Xây dựng hệ thống địa đạo: menu cửa, di chuyển nhanh, quân y.

**Vũ Huy Hoàng**:
- Phát triển hệ thống chọn đơn vị RTS.
- Gán và quản lý nhóm đơn vị, giao diện nhóm.
- Tạo prefab súng và UI kho vũ khí.
- Kết hợp UI nhóm với camera theo dõi đơn vị.
- Xử lý giao diện thông tin đơn vị, tìm và tích hợp âm thanh.

**Trần Thị Phương Trinh**:
- Tạo Tilemap và bản đồ địa đạo.
- Thiết kế UI nhóm và giao diện MainMenu, GameOver.
- Thêm các loại đạn cho súng, xử lý camera theo dõi unit.
- Lập trình khu chữa trị, xử lý logic thắng–thua cuối trận.

**Trần Kim Minh**:
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

  <img width="1522" height="689" alt="Screenshot 2025-06-25 111437" src="https://github.com/user-attachments/assets/b1711c46-9228-4c1c-bc2c-d8cfb4148d77" />

- Menu di chuyển nhanh:

  <img width="724" height="567" alt="Screenshot 2025-07-06 221655" src="https://github.com/user-attachments/assets/1fcff1a9-8970-4a4e-9288-e76062f9ed9b" />

-Mặt đất:

  <img width="1638" height="957" alt="Screenshot 2025-07-16 234720" src="https://github.com/user-attachments/assets/4cdb865f-aec7-45c6-8208-ed7fa8c37d34" />

-Địa Đạo:
  <img width="1643" height="952" alt="Screenshot 2025-07-16 234733" src="https://github.com/user-attachments/assets/dd70ccda-706b-4ef9-9f16-c9db5e2acb9e" />

  Quân ta:
- Bộ đội
  
  <img width="128" height="128" alt="BoDoi" src="https://github.com/user-attachments/assets/4e302619-6a96-4ef4-8983-91754b6c8392" />
- Quân y
  
  <img width="128" height="128" alt="QuanY" src="https://github.com/user-attachments/assets/67f04a8b-a2b6-4c03-af7e-199748d0a70f" />
- Du kích
  
  <img width="128" height="128" alt="NamDuKich-01" src="https://github.com/user-attachments/assets/399132e6-a010-4308-bd28-c25c6efb10af" />

  <img width="128" height="128" alt="NuDuKich-BaoXe-01" src="https://github.com/user-attachments/assets/b06832df-0315-4160-b027-9a25b581db34" />

Quân địch
- Bộ binh
  
  <img width="128" height="128" alt="My" src="https://github.com/user-attachments/assets/0e381371-e659-4798-8e5f-6611f4cf6c0e" />
