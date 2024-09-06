import axios from "axios";

export default axios.create({
    baseURL: "http://localhost:7006",
    headers: {
        "Content-type": "application/json",
    },
});