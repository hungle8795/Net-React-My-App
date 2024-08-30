import { FC } from "react";
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import AddCategory from "../components/Category/Create";
import CategoryList from "../components/Category/Categories";
import DeleteCategory from "../components/Category/Delete";
import UpdateCategory from "../components/Category/Update";
import Products from "./Product/Products";
import UploadImage from "./UploadImage";

const Body: FC = () => {
    return (
        <div className="margin-top-60px">
            <Router>
                <Routes>
                    {/*<Route path="/" element={<Home />} />*/}
                    {/*<Route path="/login" element={<Login />} />*/}
                    <Route path="/" element={<CategoryList />} />
                    <Route path="/updatecategory" element={<UpdateCategory onUpdate={() => { }} />} />
                    <Route path="/addcategory/:id" element={<AddCategory onCreate={() => { }} />} />
                    <Route path="/deletecategory/:id" element={<DeleteCategory />} />
                    <Route path="/products" element={<Products />} />
                    <Route path="/uploadimage" element={<UploadImage /> } />
                </Routes>
            </Router>
        </div>
    );
};

export default Body;