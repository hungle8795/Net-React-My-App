import axios from "axios";
import { useState } from "react";
import { DotNetApi } from "../helpers/DotNetApi";

const Auth = () => {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [isRegistering, setIsRegistering] = useState(true);
    const handleSubmit = async (event: React.FormEvent) => {
        event.preventDefault();
        try {
            if (isRegistering) {
                await axios.post(DotNetApi + "auth/register", { username, password });
                alert("Registration successful! You can now log in.");
            } else {
                const response = await axios.post(DotNetApi + "auth/login", { username, password });
                localStorage.setItem("token", response.data.token);
                alert("Login success!");
            }
        } catch (error) {
            console.error("Authenication failed: ", error);
            alert("Authentication failed. Please check your credentials.");
        }
    };
    return (
        <form onSubmit={handleSubmit}>
            <input
                type="text"
                placeholder="UserName"
                value={username}
                onChange={(e) => setUsername(e.target.value)}
                required
            ></input>
            <input
                type="password"
                placeholder="Password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                required
            ></input>
            <button type="submit">{isRegistering ? "Register" : "Login"}</button>
            <button type="button" onClick={() => setIsRegistering(!isRegistering)}>
                Switch to {isRegistering ? "Login" : "Register"}
            </button>
        </form>
    );
};
export default Auth;