# 中药快快记答题程序（VB.NET WinForms 版）

这是一个用于练习中药功效记忆背诵的答题程序，也是作者个人首次练习VB.NET数据库操作的项目，使用这些技术栈进行开发：VB.NET + Windows Forms + EF Core SQLite

该程序在Windows桌面环境下运行，其功能与C# MAUI版完全相同（详见[与C# MAUI版对比](#与c-maui版对比)章节）；首次运行时会自动创建SQLite数据库并初始化中药数据，无需手动配置题目数据库。

## 功能特性

- 中药功效题库（430味中药）
- 随机打乱答题顺序
- 30秒限时答题
- 自动提交超时答案
- 实时得分统计
- 数据库自动初始化

## 技术栈

- **语言**: VB.NET (.NET 9)
- **框架**: Windows Forms
- **数据库**: SQLite
- **ORM**: Entity Framework Core (VB版)

## 项目结构

```
中药快快记答题程序/
├── frmMain.vb           # 主窗体（包含答题逻辑）
├── frmMain.Designer.vb  # 窗体设计器
├── frmMain.resx         # 资源文件
├── ZhongYaoContext.vb   # EF Core 数据库上下文
├── 中药快快记答题程序.vbproj  # 项目文件
├── 中药快快记答题程序.sln     # 解决方案文件
└── README.md            # 项目说明
```

## 安装与运行

### 前置要求

- Visual Studio 2022 或更高版本
- [.NET SDK 9](https://dotnet.microsoft.com/download/dotnet/9.0)

### 运行步骤

1. 使用终端命令克隆或下载该项目：
```bash
git clone https://github.com/Pac-Dessert1436/ZhongYaoQuickMemo-VB-WinForms.git
cd ZhongYaoQuickMemo-VB-WinForms
```
2. 通过Visual Studio打开`中药快快记答题程序.sln`
3. 恢复NuGet包，并按F5启动项目

## 使用说明

1. **开始答题**: 点击“开始”按钮
2. **选择模式**: 选择是否打乱题库顺序
3. **回答问题**: 在输入框中输入中药功效
4. **提交答案**: 点击“提交”按钮或等待30秒自动提交
5. **查看结果**: 程序会显示正确答案和得分
6. **重新开始**: 点击“重新开始”按钮可重新答题

## 与C# MAUI版对比

本程序功能与[ZhongYaoQuickMemo-MauiApp](https://github.com/Pac-Dessert1436/ZhongYaoQuickMemo-MauiApp) 完全相同，主要区别：

| 特性 | C# MAUI 版 | VB.NET 版 |
|------|-----------|----------|
| 平台 | 跨平台 (MAUI) | Windows 桌面 |
| 数据存储 | YAML 文件 | SQLite 数据库 |
| 语言 | C# | VB.NET |
| UI框架 | MAUI | Windows Forms |

## 数据库结构（表名：ZhongYaoTable）

| 字段 | 类型 | 说明 |
|------|------|------|
| Id | INTEGER | 主键，自增 |
| Name | TEXT | 中药名称 |
| Description | TEXT | 药用功效 |

## 练习 VB.NET 数据库操作

本项目适合练习以下 EF Core 操作：

1. **DbContext 创建**: `ZhongYaoContext.vb` 展示了如何创建数据库上下文
2. **数据库初始化**: `EnsureCreated()` 方法自动创建数据库
3. **数据插入**: `Add()` 和 `SaveChanges()` 方法插入数据
4. **数据查询**: `ToDictionary()` 方法查询数据
5. **LINQ 查询**: 使用 LINQ 进行数据筛选

## 许可证

[BSD-3-Clause License](LICENSE)