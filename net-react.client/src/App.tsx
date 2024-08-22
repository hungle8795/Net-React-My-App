//import { useEffect, useState } from 'react';
import './App.css';
import CategoryList from './CategoryList';
import AddCategory from './AddCategory';
import DeleteCategory from './DeleteCategory';
import React from 'react';
import UpdateCategory from './UpdateCategory';
import Header from './components/Header';
import Footer from './components/Footer';
import 'bootstrap/dist/css/bootstrap.min.css';
import './index.css';
import './index.tsx'


//interface Forecast {
//    date: string;
//    temperatureC: number;
//    temperatureF: number;
//    summary: string;
//}

//function App() {
//    const [forecasts, setForecasts] = useState<Forecast[]>();

//    useEffect(() => {
//        populateWeatherData();
//    }, []);

//    const contents = forecasts === undefined
//        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
//        : <table className="table table-striped" aria-labelledby="tabelLabel">
//            <thead>
//                <tr>
//                    <th>Date</th>
//                    <th>Temp. (C)</th>
//                    <th>Temp. (F)</th>
//                    <th>Summary</th>
//                </tr>
//            </thead>
//            <tbody>
//                {forecasts.map(forecast =>
//                    <tr key={forecast.date}>
//                        <td>{forecast.date}</td>
//                        <td>{forecast.temperatureC}</td>
//                        <td>{forecast.temperatureF}</td>
//                        <td>{forecast.summary}</td>
//                    </tr>
//                )}
//            </tbody>
//        </table>;

//    return (
//        <div>
//            <h1 id="tabelLabel">Hi! Weather forecast</h1>
//            <p>This component demonstrates fetching data from the server.</p>
//            {contents}
//        </div>
//    );

//    async function populateWeatherData() {
//        const response = await fetch('weatherforecast');
//        const data = await response.json();
//        setForecasts(data);
//    }
//}

const App: React.FC = () => {
    return (
        <div className="App">
            {/*<header className="App-header">*/}
            {/*</header>*/}
            <Header />
            <div className="margin-top-60px">
                <CategoryList />
                <AddCategory />
                <DeleteCategory />
                <UpdateCategory />
            </div>
            <hr></hr>
            <Footer />
        </div>
    );
};

export default App;