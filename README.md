# 🐣 CivCiv - Unity 3D Adventure Game

<div align="center">
  <img src="https://img.shields.io/badge/Unity-2022.3+-blue.svg" alt="Unity Version">
  <img src="https://img.shields.io/badge/Platform-Windows-lightgrey.svg" alt="Platform">
  <img src="https://img.shields.io/badge/Genre-3D%20Adventure-green.svg" alt="Genre">
  <img src="https://img.shields.io/badge/Status-In%20Development-orange.svg" alt="Status">
</div>

---
<img width="1919" height="1077" alt="Ekran görüntüsü 2025-09-28 215339" src="https://github.com/user-attachments/assets/35a52d2a-f731-4f74-ba2b-4159a4d3956c" />
<img width="1919" height="1079" alt="Ekran görüntüsü 2025-09-28 215352" src="https://github.com/user-attachments/assets/f492aab6-46d7-4512-97a7-61b462c3fc81" />
<img width="1919" height="1079" alt="Ekran görüntüsü 2025-09-28 215426" src="https://github.com/user-attachments/assets/975f0544-67cb-48ba-b2c3-650b86d9d5b2" />

## 🌐 Language / Dil

🇺🇸 **[English](#english)** | 🇹🇷 **[Türkçe](#türkçe)**

---

## English

## 🎮 Game Overview

**CivCiv** is an exciting 3D adventure game built with Unity where players control a character in a dynamic world filled with collectibles, power-ups, and challenging obstacles. The game features a unique cat AI that pursues the player, creating thrilling chase sequences and strategic gameplay.

### 🎯 Game Objective
Collect all 5 eggs scattered throughout the level while avoiding the persistent cat enemy and managing various power-ups and obstacles.

## ✨ Key Features

### 🏃‍♂️ **Dynamic Player Movement**
- **Smooth 3D Movement**: WASD controls for fluid character movement
- **Advanced Jumping System**: Space bar for jumping with cooldown mechanics
- **Sliding Mechanics**: Q key for sliding with enhanced speed and drag
- **State-Based Animation**: Seamless transitions between idle, walking, jumping, and sliding states

### 🐱 **Intelligent Cat AI**
- **Multi-State Behavior**: Idle, Walking, Running, and Attacking states
- **Dynamic Pursuit**: Cat chases player when on ground, becomes passive when player is airborne
- **Smart Pathfinding**: Uses Unity NavMesh for realistic movement patterns
- **Attack System**: Close-range attack mechanics with proper range detection

### 🥚 **Collectible System**
- **Egg Collection**: Primary objective - collect all 5 eggs to win
- **Wheat Power-ups**: Three different types of wheat with unique effects:
  - 🌾 **Gold Wheat**: Increases movement speed temporarily
  - ✨ **Holy Wheat**: Enhances jump force for better mobility
  - 🍂 **Rotten Wheat**: Decreases movement speed (negative effect)
- **Visual Feedback**: Real-time UI updates and camera shake effects

### 🎨 **Rich Visual Experience**
- **Stylized Water System**: Beautiful water effects using Bitgem StylisedWater
- **Particle Effects**: Enhanced visual feedback for interactions
- **Smooth Animations**: DOTween integration for polished UI and object animations
- **Camera Shake**: Cinemachine-powered camera effects for impact feedback

### 🎵 **Audio System**
- **Comprehensive Sound Design**: 15 different sound types including:
  - Jump sounds, pickup effects, win/lose music
  - Cat sounds, interaction feedback, UI button sounds
- **Background Music**: Dynamic music system with play/pause functionality
- **Audio Management**: Centralized audio system with proper volume controls

### 🎮 **User Interface**
- **Real-time Player State UI**: Visual representation of current player state
- **Booster Status Display**: Shows active power-up effects with animations
- **Win/Lose Screens**: Complete game over screens with timer display
- **Settings Menu**: Music and sound controls with pause functionality
- **Timer System**: Tracks completion time for performance measurement

## 🎮 Controls

| Action | Key | Description |
|--------|-----|-------------|
| **Movement** | `WASD` | Move character in 3D space |
| **Jump** | `Space` | Jump with cooldown system |
| **Slide** | `Q` | Slide for increased speed |
| **Pause** | `ESC` | Open settings menu |

## 🛠️ Technical Features

### **Unity Technologies Used**
- **Unity 2022.3+** - Latest Unity LTS version
- **Cinemachine** - Advanced camera system
- **DOTween** - Smooth animations and transitions
- **Unity Input System** - Modern input handling
- **NavMesh** - AI pathfinding
- **TextMeshPro** - High-quality text rendering

### **Code Architecture**
- **State Machine Pattern** - Clean player and AI state management
- **Event-Driven System** - Decoupled communication between systems
- **Scriptable Objects** - Data-driven design for collectibles
- **Interface-Based Design** - Modular collectible and boostable systems
- **Singleton Pattern** - Centralized managers for game state and audio

### **Performance Optimizations**
- **Object Pooling** - Efficient collectible respawning
- **LOD System** - Level of detail for distant objects
- **Efficient State Management** - Minimal computational overhead
- **Memory Management** - Proper cleanup and resource management

## 📁 Project Structure

```
Assets/
├── _GameAssets/
│   ├── Scripts/
│   │   ├── Managers/          # Game management systems
│   │   ├── Player/            # Player controller and states
│   │   ├── Cat/              # AI cat behavior
│   │   ├── Collectibles/     # Collectible items system
│   │   ├── UI/               # User interface components
│   │   ├── Water/            # Water system integration
│   │   └── Enums/            # Game state definitions
│   ├── Scenes/               # Game scenes
│   └── [Other Assets]        # Models, textures, audio
├── Plugins/                  # Third-party plugins
└── Settings/                 # Unity project settings
```

## 🚀 Getting Started

### Prerequisites
- Unity 2022.3 LTS or later
- Windows 10/11 (64-bit)
- Visual Studio 2022 (recommended)

### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/EsrefEmreBayrakci/civciv
   cd civciv
   ```

2. Open the project in Unity Hub
3. Wait for Unity to import all assets and compile scripts
4. Open the `GameScene` from the Scenes folder
5. Press Play to start the game

### Building the Game
1. Go to `File > Build Settings`
2. Select your target platform
3. Click `Build` or `Build and Run`

💡 Alternatively: If you have downloaded the built version, you can run the game.exe file inside the CikWick Game folder to play the game directly. Unity installation is not required.

---

## Türkçe

## 🎮 Oyun Genel Bakış

**CivCiv**, Unity ile geliştirilmiş heyecan verici bir 3D macera oyunudur. Oyuncular, koleksiyon eşyaları, güçlendirici öğeler ve zorlu engellerle dolu dinamik bir dünyada karakterlerini kontrol ederler. Oyun, oyuncuyu takip eden benzersiz bir kedi yapay zekası içerir ve bu da heyecanlı kovalamaca sekansları ve stratejik oynanış yaratır.

### 🎯 Oyun Amacı
Seviyede dağılmış olan 5 yumurtanın tümünü toplarken, ısrarcı kedi düşmanından kaçının ve çeşitli güçlendirici öğeleri ve engelleri yönetin.

## ✨ Temel Özellikler

### 🏃‍♂️ **Dinamik Oyuncu Hareketi**
- **Akıcı 3D Hareket**: WASD kontrolleri ile pürüzsüz karakter hareketi
- **Gelişmiş Zıplama Sistemi**: Bekleme süresi mekanikleri ile Space tuşu ile zıplama
- **Kayma Mekanikleri**: Gelişmiş hız ve sürtünme ile Q tuşu ile kayma
- **Durum Tabanlı Animasyon**: Boşta, yürüme, zıplama ve kayma durumları arasında kusursuz geçişler

### 🐱 **Akıllı Kedi Yapay Zekası**
- **Çoklu Durum Davranışı**: Boşta, Yürüme, Koşma ve Saldırı durumları
- **Dinamik Takip**: Kedi, oyuncu yerdeyken takip eder, oyuncu havadayken pasif hale gelir
- **Akıllı Yol Bulma**: Gerçekçi hareket kalıpları için Unity NavMesh kullanır
- **Saldırı Sistemi**: Uygun menzil algılaması ile yakın mesafe saldırı mekanikleri

### 🥚 **Koleksiyon Sistemi**
- **Yumurta Toplama**: Birincil amaç - kazanmak için 5 yumurtanın tümünü toplayın
- **Buğday Güçlendiricileri**: Benzersiz etkilere sahip üç farklı buğday türü:
  - 🌾 **Altın Buğday**: Hareket hızını geçici olarak artırır
  - ✨ **Kutsal Buğday**: Daha iyi mobilite için zıplama kuvvetini artırır
  - 🍂 **Çürük Buğday**: Hareket hızını azaltır (olumsuz etki)
- **Görsel Geri Bildirim**: Gerçek zamanlı UI güncellemeleri ve kamera sallama efektleri

### 🎨 **Zengin Görsel Deneyim**
- **Stilize Su Sistemi**: Bitgem StylisedWater kullanarak güzel su efektleri
- **Parçacık Efektleri**: Etkileşimler için gelişmiş görsel geri bildirim
- **Akıcı Animasyonlar**: Cilalı UI ve nesne animasyonları için DOTween entegrasyonu
- **Kamera Sallama**: Etki geri bildirimi için Cinemachine destekli kamera efektleri

### 🎵 **Ses Sistemi**
- **Kapsamlı Ses Tasarımı**: Şunları içeren 15 farklı ses türü:
  - Zıplama sesleri, toplama efektleri, kazanma/kaybetme müziği
  - Kedi sesleri, etkileşim geri bildirimi, UI düğme sesleri
- **Arkaplan Müziği**: Oynat/duraklat işlevselliği ile dinamik müzik sistemi
- **Ses Yönetimi**: Uygun ses seviyesi kontrolleri ile merkezi ses sistemi

### 🎮 **Kullanıcı Arayüzü**
- **Gerçek Zamanlı Oyuncu Durumu UI**: Mevcut oyuncu durumunun görsel temsili
- **Güçlendirici Durum Gösterimi**: Animasyonlarla aktif güçlendirici efektlerini gösterir
- **Kazanma/Kaybetme Ekranları**: Zamanlayıcı gösterimi ile tam oyun sonu ekranları
- **Ayarlar Menüsü**: Duraklama işlevselliği ile müzik ve ses kontrolleri
- **Zamanlayıcı Sistemi**: Performans ölçümü için tamamlanma süresini takip eder

## 🎮 Kontroller

| Eylem | Tuş | Açıklama |
|-------|-----|----------|
| **Hareket** | `WASD` | Karakteri 3D uzayda hareket ettir |
| **Zıplama** | `Space` | Bekleme süresi sistemi ile zıpla |
| **Kayma** | `Q` | Artırılmış hız için kay |
| **Duraklat** | `ESC` | Ayarlar menüsünü aç |

## 🛠️ Teknik Özellikler

### **Kullanılan Unity Teknolojileri**
- **Unity 2022.3+** - En son Unity LTS sürümü
- **Cinemachine** - Gelişmiş kamera sistemi
- **DOTween** - Akıcı animasyonlar ve geçişler
- **Unity Input System** - Modern girdi işleme
- **NavMesh** - AI yol bulma
- **TextMeshPro** - Yüksek kaliteli metin oluşturma

### **Kod Mimarisi**
- **State Machine Pattern** - Temiz oyuncu ve AI durum yönetimi
- **Event-Driven System** - Sistemler arası ayrıştırılmış iletişim
- **Scriptable Objects** - Koleksiyon eşyaları için veri odaklı tasarım
- **Interface-Based Design** - Modüler koleksiyon ve güçlendirilebilir sistemler
- **Singleton Pattern** - Oyun durumu ve ses için merkezi yöneticiler

### **Performans Optimizasyonları**
- **Object Pooling** - Verimli koleksiyon eşyası yeniden doğurma
- **LOD System** - Uzak nesneler için detay seviyesi
- **Efficient State Management** - Minimal hesaplama yükü
- **Memory Management** - Uygun temizlik ve kaynak yönetimi

## 📁 Proje Yapısı

```
Assets/
├── _GameAssets/
│   ├── Scripts/
│   │   ├── Managers/          # Oyun yönetim sistemleri
│   │   ├── Player/            # Oyuncu kontrolcüsü ve durumları
│   │   ├── Cat/              # AI kedi davranışı
│   │   ├── Collectibles/     # Koleksiyon eşyaları sistemi
│   │   ├── UI/               # Kullanıcı arayüzü bileşenleri
│   │   ├── Water/            # Su sistemi entegrasyonu
│   │   └── Enums/            # Oyun durumu tanımları
│   ├── Scenes/               # Oyun sahneleri
│   └── [Diğer Varlıklar]     # Modeller, dokular, ses
├── Plugins/                  # Üçüncü taraf eklentiler
└── Settings/                 # Unity proje ayarları
```

## 🚀 Başlangıç

### Ön Koşullar
- Unity 2022.3 LTS veya sonrası
- Windows 10/11 (64-bit)
- Visual Studio 2022 (önerilen)

### Kurulum
1. Repository'yi klonlayın:
   ```bash
   git clone https://github.com/EsrefEmreBayrakci/civciv
   cd civciv
   ```

2. Projeyi Unity Hub'da açın
3. Unity'nin tüm varlıkları içe aktarmasını ve scriptleri derlemesini bekleyin
4. Scenes klasöründen `GameScene`'i açın
5. Oyunu başlatmak için Play'e basın

### Oyunu Derleme
1. `File > Build Settings`'e gidin
2. Hedef platformunuzu seçin
3. `Build` veya `Build and Run`'a tıklayın

💡 Alternatif olarak: Derlenmiş sürümü indirdiyseniz, CikWick Game klasöründeki game.exe dosyasını çalıştırarak oyunu doğrudan oynayabilirsiniz. Unity kurmanıza gerek yoktur.


