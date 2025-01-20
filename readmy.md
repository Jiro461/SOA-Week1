# Mô Tả Dự Án SOAHomeWork

## Tổng Quan
Dự án này triển khai một Web Service sử dụng ASP.NET Web Services (ASMX) để cung cấp các phương thức truy xuất thông tin về các quốc gia và thành phố từ cơ sở dữ liệu. Dự án bao gồm các phần: 

- **Server-side**: Lớp `DatabaseManagement` quản lý các thao tác với cơ sở dữ liệu và `MyServices.asmx.cs` triển khai các phương thức Web Service.
- **Client-side**: Ứng dụng Windows Forms (ClientSOA) sử dụng Web Service để hiển thị dữ liệu lên giao diện người dùng.

---

## Phần Server

### **1. DatabaseManagement.cs**
Lớp `DatabaseManagement` thực hiện các thao tác với cơ sở dữ liệu. Dưới đây là các phương thức của lớp:

| Phương Thức | Mô Tả                                                                 |
|-------------|----------------------------------------------------------------------|
| `getAllCountry()` | Lấy tất cả các quốc gia từ cơ sở dữ liệu (50 quốc gia).               |
| `getCountrybyCode(string code)` | Lấy quốc gia dựa trên mã quốc gia.                                       |
| `getCityByName(string name)` | Lấy thành phố theo tên thành phố.                                           |
| `getAllCitiesOfCountry(string country)` | Lấy tất cả các thành phố trong một quốc gia cụ thể.                        |
| `getAllCountryByPopulation(int population)` | Lấy tất cả quốc gia có dân số lớn hơn hoặc bằng giá trị cụ thể.            |
| `getAllCountryByGNP(decimal GNP)` | Lấy tất cả quốc gia có GNP lớn hơn hoặc bằng giá trị cụ thể.                 |
| `getOfficialLanguageByCountryName(string countryName)` | Lấy ngôn ngữ chính thức của một quốc gia dựa trên tên quốc gia.              |

### **2. MyServices.asmx.cs**
`MyServices` là Web Service triển khai các phương thức trên và có thể được gọi từ client. Các phương thức bao gồm:

| Phương Thức | Mô Tả                                                             |
|-------------|------------------------------------------------------------------|
| `HelloWorld()` | Trả về chuỗi "Hello World".                                       |
| `getAllCountry()` | Lấy tất cả các quốc gia.                                           |
| `getCountryByCode(string code)` | Lấy quốc gia theo mã quốc gia.                                          |
| `getCityByName(string name)` | Lấy thành phố theo tên.                                               |
| `getCityBySpecificCountry(string country)` | Lấy thành phố của một quốc gia cụ thể.                               |
| `getAllCountryByPopulation(int population)` | Lấy quốc gia có dân số lớn hơn hoặc bằng giá trị cụ thể.               |
| `getAllCountryByGNP(decimal GNP)` | Lấy quốc gia có GNP lớn hơn hoặc bằng giá trị cụ thể.                  |
| `getOfficialLanguageByCountryName(string countryName)` | Lấy ngôn ngữ chính thức của quốc gia.                                |

---

## Phần Client

### **ClientSOA (Ứng dụng Windows Forms)**

Ứng dụng Windows Forms thực hiện các thao tác tương tác với Web Service đã triển khai. Các phương thức trong `Form1` sẽ gọi các Web Method từ Web Service và hiển thị kết quả trên giao diện người dùng. Các nút tương tác bao gồm:

| Nút         | Mô Tả                                                            |
|-------------|-----------------------------------------------------------------|
| `serviceButton1_Click()` | Gọi phương thức `getAllCountry()` và hiển thị kết quả.                   |
| `serviceButton2_Click()` | Gọi phương thức `getCountryByCode()` và hiển thị kết quả dựa trên mã quốc gia. |
| `serviceButton3_Click()` | Gọi phương thức `getCityByName()` và hiển thị các thành phố theo tên.    |
| `serviceButton4_Click()` | Gọi phương thức `getCityBySpecificCountry()` và hiển thị các thành phố của một quốc gia. |
| `serviceButton5_Click()` | Gọi phương thức `getAllCountryByPopulation()` và hiển thị các quốc gia có dân số lớn hơn giá trị nhập vào. |
| `serviceButton6_Click()` | Gọi phương thức `getAllCountryByGNP()` và hiển thị các quốc gia có GNP lớn hơn giá trị nhập vào. |
| `serviceButton7_Click()` | Gọi phương thức `getOfficialLanguageByCountryName()` và hiển thị ngôn ngữ chính thức của quốc gia. |

### **Giải Thích Code Client**
- **Web Service Client**: `MyServicesSoapClient` được sử dụng để kết nối và gọi các phương thức từ Web Service.
- **`InvokeService<T>`**: Là phương thức chung để gọi Web Service và hiển thị kết quả vào `DataGridView`. Phương thức này giúp tái sử dụng mã nguồn cho nhiều yêu cầu khác nhau.
- **Xử lý sự kiện Button**: Mỗi nút trên giao diện người dùng tương ứng với một yêu cầu đến Web Service, gửi thông tin và hiển thị kết quả.

---

## Các Tính Năng Đạt Được
- **Quản lý Quốc Gia và Thành Phố**: API cung cấp các phương thức để lấy thông tin về quốc gia, thành phố, ngôn ngữ chính thức và các dữ liệu liên quan.
- **Dữ Liệu Chính Thức**: Cung cấp ngôn ngữ chính thức của quốc gia.
- **Giao Diện Người Dùng**: Ứng dụng Windows Forms giúp người dùng tương tác trực tiếp với Web Service để truy vấn dữ liệu và hiển thị kết quả trong bảng.

---

## Công Nghệ Sử Dụng
- **Backend**: ASP.NET Web Services (ASMX), Entity Framework
- **Frontend**: Windows Forms (C#)
- **Database**: SQL Server (hoặc hệ quản trị cơ sở dữ liệu khác tùy vào triển khai)
- **Web Service**: SOAP Web Service

---

## Tài Liệu API

- **`HelloWorld()`**: Trả về "Hello World" để kiểm tra kết nối API.
- **`getAllCountry()`**: Trả về danh sách tất cả quốc gia.
- **`getCountryByCode(string code)`**: Trả về quốc gia theo mã code.
- **`getCityByName(string name)`**: Trả về các thành phố với tên cụ thể.
- **`getCityBySpecificCountry(string country)`**: Trả về các thành phố của quốc gia.
- **`getAllCountryByPopulation(int population)`**: Trả về các quốc gia có dân số lớn hơn hoặc bằng giá trị cụ thể.
- **`getAllCountryByGNP(decimal GNP)`**: Trả về các quốc gia có GNP lớn hơn hoặc bằng giá trị cụ thể.
- **`getOfficialLanguageByCountryName(string countryName)`**: Trả về ngôn ngữ chính thức của quốc gia.

---

## Kết Luận
Dự án SOAHomeWork giúp xây dựng một hệ thống quản lý quốc gia và thành phố thông qua Web Service. Các API được triển khai hiệu quả, giúp lấy và thao tác dữ liệu liên quan đến các quốc gia, thành phố, dân số và ngôn ngữ chính thức. Ứng dụng Client-side dễ dàng kết nối và truy xuất các dữ liệu này để phục vụ cho các mục đích xử lý thông tin hoặc nghiên cứu.