# Klod Tattoo Studio - Static Blazor WebAssembly Site

## 🎨 Project Overview

This is a **fully static Blazor WebAssembly** website for Klod Tattoo Studio, designed to showcase tattoo artwork with a beautiful, responsive design and 3-language support.

### Features
- ✅ **3 Languages**: Italian, English, German
- ✅ **Dark Theme** with gold (#d4af37) accents
- ✅ **Portfolio Gallery** with category filtering
- ✅ **Responsive Design** (mobile-first)
- ✅ **No Backend Required** - completely static
- ✅ **F REE Hosting** compatible (GitHub Pages, Netlify, Vercel Ore)

---

## 🚀 Quick Start

### Prerequisites
- [.NET SDK 10.0+](https://dotnet.microsoft.com/download)

### Running Locally
```bash
cd KlodTattooWebStatic
dotnet run
```

The site will be available at `https://localhost:5001`

---

## 📁 Project Structure

```
KlodTattooWebStatic/
├── Pages/                  # Razor pages (Home, Portfolio, Services, Info, Contacts)
├── Layout/                 # MainLayout with navbar and footer
├── Models/                 # Data models (TattooItem, TattooCategory, TattooData)
├── Services/               # Services (LocalizationService, TattooDataService)
├── wwwroot/
│   ├── css/app.css        # Main stylesheet
│   ├── js/site.js         # JavaScript interactions
│   ├── data/tattoos.json  # Tattoo data and categories
│   ├── Resources/         # JSON localization files (it, en, de)
│   └── images/
│       ├── klod_logo.png
│       ├── hero.jpg
│       └── tattoos/       # Tattoo photos organized by category
│           ├── traditional/
│           ├── realistico/
│           └── blackwork/
├── Program.cs
└── README.md
```

---

## 📸 Adding New Tattoo Photos

### Step 1: Add the Image

1. Copy your image to the appropriate category folder:
   ```
   wwwroot/images/tattoos/{category}/your-image.jpg
   ```

2. Supported categories: `traditional`, `realistico`, `blackwork`

### Step 2: Update `tattoos.json`

Edit `wwwroot/data/tattoos.json` and add a new entry:

```json
{
  "id": 5,
  "title": "Your Tattoo Title",
  "category": "traditional",
  "imageUrl": "/images/tattoos/traditional/your-image.jpg",
  "createdDate": "2025-01-15"
}
```

### Step 3: Deploy

Commit changes and deploy:
```bash
git add .
git commit -m "Add new tattoo photo"
git push
```

Your hosting provider will automatically rebuild and redeploy the site.

---

## 🌐 Changing Translations

Translation files are in `wwwroot/Resources/`:
- `Localization.it.json` - Italian
- `Localization.en.json` - English
- `Localization.de.json` - German

Edit the JSON files to change any text on the website. Example:

```json
{
  "Nav_Home": "Home",
  "Nav_Portfolio": "Portfolio",
  "Hero_Tagline": "Art on your skin"
}
```

---

## 🚢 Deployment

### Option 1: GitHub Pages

1. Create a new repository on GitHub
2. Push your code:
   ```bash
   git init
   git add.
   git commit -m "Initial commit"
   git remote add origin https://github.com/yourusername/klod-tattoo.git
   git push -u origin main
   ```

3. Build for production:
   ```bash
   dotnet publish -c Release
   ```

4. Deploy the `bin/Release/net10.0/publish/wwwroot` folder to GitHub Pages

### Option 2: Netlify

1. Connect your GitHub repository to Netlify
2. Configure build settings:
   - **Build command**: `dotnet publish -c Release`
   - **Publish directory**: `bin/Release/net10.0/publish/wwwroot`
3. Deploy automatically on every push!

### Option 3: Vercel

1. Install Vercel CLI: `npm i -g vercel`
2. Build: `dotnet publish -c Release`
3. Deploy: `vercel --prod`

---

## 🎨 Customization

### Colors

Edit `wwwroot/css/app.css` and modify the CSS variables:

```css
:root {
    --bg-color: #121212;           /* Background */
    --surface-color: #1e1e1e;      /* Cards/surfaces */
    --text-color: #e0e0e0;         /* Text */
    --accent-color: #d4af37;       /* Gold accent */
    --accent-hover: #b5952f;       /* Gold hover */
}
```

### Fonts

The site uses:
- **Headings**: Playfair Display
- **Body**: Poppins

To change fonts, edit the Google Fonts import in `app.css`.

---

## 📷 Image Requirements

For best results:
- **Format**: JPG or PNG
- **Size**: Max 2MB per image
- **Dimensions**: 1200 x 900px (4:3 ratio) recommended
- **Optimization**: Use tools like [TinyPNG](https://tinypng.com/) to compress images

---

## 🔧 Troubleshooting

### Images Not Loading
- Ensure image paths in `tattoos.json` start with `/images/`
- Check that images are in the correct category folder
- Verify file extensions match (.jpg vs .jpeg)

### Translations Not Working
- Clear browser cache
- Check JSON syntax (use [JSONLint](https://jsonlint.com/))
- Ensure language codes match: `it`, `en`, `de`

### Build Errors
```bash
# Clean and rebuild
dotnet clean
dotnet build
```

---

## 📞 Contact

**Klod Tattoo Studio**  
Lindenstraße 26  
63785 Obernburg am Main  
Germany

📧 info.klodtattoo@gmail.com  
📱 +49 172 2487670

🔗 [Instagram](https://instagram.com/klod_tattoo)  
🔗 [Facebook](https://facebook.com/klod.backa)

---

## 📝 License

© 2025 Klod Tattoo Studio. All rights reserved.
