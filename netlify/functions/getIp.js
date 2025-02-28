const { NetlifyFunction } = require("@netlify/functions");

exports.handler = async (event) => {
    const userIp = event.headers["x-forwarded-for"] || event.requestContext?.identity?.sourceIp || "IP alınamadı";

    return {
        statusCode: 200,
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ ip: userIp }),
    };
};
