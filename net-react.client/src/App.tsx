//import { useEffect, useState } from 'react';
import './App.css';
import { FC } from 'react';
import CategoryList from './CategoryList';
import AddCategory from './AddCategory';
import DeleteCategory from './DeleteCategory';
import UpdateCategory from './UpdateCategory';
import Header from './components/Header';
import Footer from './components/Footer';
import 'bootstrap/dist/css/bootstrap.min.css';
import './index.css';
import './index.tsx'



const App: FC = () => {
    return (
        <div className="App">
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