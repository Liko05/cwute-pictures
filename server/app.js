const express = require("express");
const app = express();
const port = 3000;
const router = require("./router");

app.use(express.json({ limit: "50mb" }));
app.use(express.static("public"));
app.use("/", router);

app.listen(port, () => {
  console.log(`[Port] ${port}`);
});