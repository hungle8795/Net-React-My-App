import React, { useState } from 'react';
import axios from 'axios';
import { DotNetApi } from '../helpers/DotNetApi';

const Login = () => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');

    const handleSubmit = async (event: React.FormEvent) => {
        event.preventDefault();
        try {
            const response = await axios.post(DotNetApi + 'auth/login', { username, password });
            localStorage.setItem('token', response.data.token); // Store token in local storage
            alert('Login successful!');
        } catch (error) {
            console.error('Login failed:', error);
            alert('Login failed. Please check your credentials.');
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <input
                type="text"
                placeholder="Username"
                value={username}
                onChange={(e) => setUsername(e.target.value)}
                required
            />
            <input
                type="password"
                placeholder="Password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                required
            />
            <button type="submit">Login</button>
        </form>
    );
};

export default Login;