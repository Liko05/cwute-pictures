const fs = require("fs");

/* wannabe database*/
const list = new Map();

/**
 * It adds an image to the list.
 * @param imageName - The name of the image file.
 * @param imageTitle - The title of the image.
 * @param imageAuthor - The name of the user who uploaded the image.
 * @param imageDate - The date the image was uploaded.
 */
function addImage(imageName, imageTitle, imageAuthor, imageDate) {
  list.set(imageName, {
    name: imageTitle,
    user: imageAuthor,
    date: imageDate,
  });
}

/**
 * It takes the list variable, which is a Map, and turns it into a JSON file
 * and saves it to the list.json file.
 */
function createJsonFile() {
  var json = JSON.stringify(Array.from(list.entries()));
  fs.writeFileSync("./list.json", json);
}

/**
 * It reads a JSON file, parses it, and then adds the data to a map.
 */
function loadJsonFile() {
  var json = fs.readFileSync("./list.json", "utf-8");
  var jsonObj = JSON.parse(json);
  for (var i = 0; i < jsonObj.length; i++) {
    addImage(
      jsonObj[i][0],
      jsonObj[i][1].name,
      jsonObj[i][1].user,
      jsonObj[i][1].date
    );
  }
}

/**
 * It returns the image object from the list of images.
 * @param imageName - The name of the image to get.
 * @returns The image object.
 */
function getImageObject(imageName) {
  return list.get(imageName);
}

/* Exporting the functions and variables from the file. */
module.exports = {
  list,
  addImage,
  createJsonFile,
  loadJsonFile,
  getImageObject,
};