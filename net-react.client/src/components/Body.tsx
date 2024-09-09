import { FC } from "react";
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import CategoryList from "./Category/Categories";
import AddCategory from "./Category/Create";
import UpdateCategory from "./Category/Update";
import DeleteCategory from "./Category/Delete";
import Products from "./Product/Products";
import AddProduct from "./Product/Create";
import UpdateProduct from "./Product/Update";
import DeleteProduct from "./Product/Delete";
import UploadImage from "./UploadImage";
import Home from "./Home";

const Body: FC = () => {
    return (
        <div className="margin-top-60px">
            <Router>
                <Routes>
                    {/*<Route path="/" element={<Home />} />*/}
                    {/*<Route path="/login" element={<Login />} />*/}
                    <Route path="/" element={<Home />} />
                    <Route path="/categories" element={<CategoryList />} />
                    <Route path="/category/add/" element={<AddCategory onCreateCategory={() => { }} />} />
                    <Route path="/category/update" element={<UpdateCategory onUpdateCategory={() => { }} />} />
                    <Route path="/category/delete/:id" element={<DeleteCategory onDeleteCategory={() => { }} />} />
                    <Route path="/products/:categoryId" element={<Products />} />
                    <Route path="/products/" element={<Products />} />
                    <Route path="/product/add/" element={<AddProduct onCreateProduct={() => { }} />} />
                    <Route path="/product/update" element={<UpdateProduct onUpdateProduct={() => { }} />} />
                    <Route path="/product/delete/:id" element={<DeleteProduct onDeleteProduct={() => { }} />} />
                    <Route path="/uploadimage" element={<UploadImage />} />
                </Routes>
            </Router>
        </div>
    );
};

export default Body;