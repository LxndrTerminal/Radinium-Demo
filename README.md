# Radinium Demo

A desktop application built with **Blazor** and **.NET 10** in **C#** that demonstrates integration with the **Cryptlex API** for managing products and licenses.

## 🎯 Objective

This project fulfills the interview requirement to develop a desktop application that interacts with the Cryptlex API to:
- ✅ Create and manage multiple products
- ✅ Activate licenses
- ✅ Generate license keys

## 🛠️ Technology Stack

- **Framework**: .NET 10
- **Language**: C# (8.4%)
- **UI**: Blazor
- **Frontend**: HTML (10.9%) & CSS (74.8%)
- **Styling**: Custom CSS
- **API Integration**: Cryptlex API (EU Base Address)

## 📋 Features

- **Product Management**: Create and manage up to three products
- **License Activation**: Activate licenses with Cryptlex API
- **Key Generation**: Generate and manage license keys
- **Secure Authentication**: PAT (Personal Access Token) managed via user secrets (not committed to repository)

## 🔒 Security

This project uses **local user secrets** to store sensitive credentials:
- Cryptlex API PAT tokens


⚠️ **Never commit secrets to the repository** - User secrets are stored locally and excluded from version control.

## 🚀 Getting Started

### Prerequisites
- .NET 10 SDK
- Visual Studio 2022 or Visual Studio Code
- Cryptlex account with API access
- Cryptlex.LexActivator package

### Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/LxndrTerminal/Radinium-Demo.git
   cd Radinium-Demo
2. **Create user secret for your Personal Access Token (PLEASE NOTE: get your PAT in [Cryptlex Portal](https://app.cryptlex.com/home/overview) under Development tab - Access Tokens - Create - Tick all permissions - Copy PAT)**
   ```bash
   dotnet user-secrets Dev:PersonalAccessToken "YOUR-PERSONAL-ACCESS-TOKEN"
   
   
