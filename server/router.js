const { randomUUID } = require("crypto");
const express = require("express");
const app = express();
const fs = require("fs");
const router = express.Router();
const db = require("./db");
const xssFilters = require('xss-filters');

app.use(express.json({ limit: "50mb" }));


/*Get requests for pages*/
router.get("", (req, res) => {
  res.sendFile("./public/default_website/index.html", { root: __dirname });
});

router.get("/usage", (req, res) => {
  res.sendFile("./public/usage/index.html", { root: __dirname });
});

router.get("/errors", (req, res) => {
  res.sendFile("./public/errors/index.html", { root: __dirname });
});

router.get("/preview", (req, res) => {
  res.sendFile("./public/preview/index.html", { root: __dirname });
});

router.get("/aboutus", (req, res) => {
  res.sendFile("./public/default_website/index.html", { root: __dirname });
});

/*A get request used to get normal translate of the app */
router.get("/langs/default", (req, res) => {
  res.json({
    'titleLabel': 'welcome to cwute app here you can change settings regarding your client and uploading',
    'usernameLabel': 'Enter your desired username:',
    'selectLanguageLabel': 'Select your desired language:',
    'localSavesCheckBox': 'Do you want to enable storing images locally too?',
    'changesNotSavedLabel': 'Changes not saved',
    'saveSettingsBtn': 'Save changes',
    'siteLinkLabel': 'For more info visit our cwute site',
    'siteOpenCheck':'Enable',
    'siteOpenLabel':'Do you want to automatically open site after uploading?'
  });
});

/*A get request used to get uwufied translate of the app */
router.get("/langs/uwu", (req, res) => {
  res.json({
    'titleLabel': 'Wewcome t-to cwute app, h-h-hewe you c-can chwange settings wegawding youw cwient and upwoading.',
    'usernameLabel': 'Entew youw desiwed username:',
    'selectLanguageLabel': 'Sewect youw desiwed language:',
    'localSavesCheckBox': 'Do you w-want t-to enyabwe stowing images wocawwy too?!?1 :3',
    'changesNotSavedLabel': 'Chwanges nyot saved',
    'saveSettingsBtn': 'S-save chwanges?',
    'siteLinkLabel': 'Fow mowe info *sweats* visit ouw vewy c-cute website. cwute uwu',
    'siteOpenCheck':'Enyabwe',
    'siteOpenLabel':'Do you w-want t-to automaticawwy open site a-a-aftew upwoading?!?1 *cries*'
  });
});

/* A get request that is used to view images. */
router.get("/viewer/:pictureName", (req, res) => {

  var imageName = req.params.pictureName;
  db.loadJsonFile();
  var loadedImage = db.getImageObject(imageName);

  if (loadedImage == null) {
    res.sendFile("./public/error_site/index.html", { root: __dirname });
    return;
  }

    var content = fs.readFileSync("./public/image_viewer/index.html", "utf-8");
    var imagePath = "/" + imageName + ".png";
    var nameOfImage = loadedImage.name;
    var uploadedDate = loadedImage.date;
    var uploadedByUser = loadedImage.user;

    content = content.replace(
      "<!--ReplaceThisValue-->",
      `<img src='${xssFilters.inHTMLData(imagePath)}' alt='${xssFilters.inHTMLData(imagePath)}'>`
    );
    content = content.replace(
      "<h1>Name of screenshot</h1>",
      `<h1>${xssFilters.inHTMLData(nameOfImage)}</h1>`
    );
    content = content.replace(
      "<p>Uploaded: date By: user</p>",
      `<p>Uploaded: ${xssFilters.inHTMLData(uploadedDate)} By: ${xssFilters.inHTMLData(uploadedByUser)}</p>`
    );
    content = content.replace(
      "<title>todo</title>",
      `<title>${"Image: " + xssFilters.inHTMLData(imageName)}</title>`
    );

    content = content.replace("image-name-replace", imagePath);

    res.send(content);
});

/* Uploads image to the server  */
router.post("/v1/upload-img", express.json(), (req, res) => {

  var imageTitle = req.body.name;
  var imageAuthor = req.body.user;
  var imageDate = req.body.date;
  var imageBase64 = req.body.imagebase64;

  if (isEmptyOrSpaces(imageTitle) || isEmptyOrSpaces(imageAuthor) || isEmptyOrSpaces(imageDate) || isEmptyOrSpaces(imageBase64)) {
    res.json({ status: "false", message: "Null data or whitespace parameters" });
    return;
  }
  if (imageTitle == undefined || imageAuthor == undefined || imageDate == undefined || imageBase64 == undefined) {
    res.json({ status: "false", message: "Undefined data" });
    return;
  }

  if (imageTitle.length >= 32 || imageAuthor.length >= 20 || imageDate.length >= 12) {
    res.json({ status: 'false', message: "Incorrect parameter legths" });
    return;
  }
  
  if (imageTitle == "" || imageAuthor == "" || imageDate == "" || imageBase64 == "") {
    res.json({ status: "false", message: "Empty fields" });
    return;
  }
 // if()

  var randomImageName = randomUUID() + ".png";
  let buff = Buffer.from(imageBase64, "base64");

  try {
    fs.writeFileSync("./public/" + randomImageName, buff);
  } catch (err) {
    res.json({ status: "false", message: "Error writing the image" });
    return;
  }

  db.loadJsonFile();
  db.addImage(randomImageName.replace(".png", ""), imageTitle, imageAuthor, imageDate);
  db.createJsonFile();
  console.log('[Debug] Uploaded image: ' + randomImageName);
  res.json({ status: "true", message: randomImageName.replace(".png", "") });
});

router.get("/v1/upload-img", (req, res) => {
  res.send("nothing to see here!");
});

function isEmptyOrSpaces(str){
  return str === null || str.match(/^ *$/) !== null;
}

module.exports = router;