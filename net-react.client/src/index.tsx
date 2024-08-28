import ReactDOM from 'react-dom/client';
import App from './App';
import './index.css';
import AuthContextProvider from './auth/auth.context';
import { BrowserRouter } from 'react-router-dom';

ReactDOM.createRoot(document.getElementById('root')!).render(
  <BrowserRouter>
    <AuthContextProvider>
      <App />
    </AuthContextProvider>
  </BrowserRouter>
);
