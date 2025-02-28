const express = require("express");

const app = express();
const PORT = 3000;

// IP adresini al ve ekrana yazdır
app.get("/", (req, res) => {
    const userIp = req.headers["x-forwarded-for"] || req.socket.remoteAddress;
    res.send(`Kullanıcının IP adresi: ${userIp}`);
});

app.listen(PORT, () => {
    console.log(`Sunucu ${PORT} portunda çalışıyor...`);
});
