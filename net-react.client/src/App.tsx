//import { useEffect, useState } from 'react';
import './App.css';
import { FC } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import './index.css';
import './index.tsx';
import HomePage from './components/HomePage';



const App: FC = () => {
    return (
        //<div className="App">
        //    <Header />
        //    <div className="margin-top-60px">
        //        <CategoryList />
        //        <AddCategory />
        //        <DeleteCategory />
        //        <UpdateCategory />
        //    </div>
        //    <hr></hr>
        //    <Footer />
        //</div>

        //<div className="App">
        //    <Header />
        //    <div className="margin-top-60px">
        //        <Router>
        //            <Routes>
        //                {/*<Route path="/" element={<Home />} />*/}
        //                {/*<Route path="/login" element={<Login />} />*/}
        //                <Route path="/" element={<CategoryList />} />
        //                <Route path="/updateCategory" element={<UpdateCategory onAdd={() => { }} />} />
        //                {/*<Route path="/updateCategory" element={<UpdateCategory />} />*/}
        //                <Route path="/addCategory/:id" element={<AddCategory onAdd={() => { }} />} />
        //                <Route path="/deleteCategory/:id" element={<DeleteCategory />} />
        //            </Routes>
        //        </Router>
        //    </div>
        //    <hr></hr>
        //    <Footer />
        //</div>
        <HomePage />
    );
};

export default App;