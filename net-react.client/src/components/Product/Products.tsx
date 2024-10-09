import axios from "axios";
import { FC, useState, useEffect } from "react";
import { DotNetApi } from "../../helpers/DotNetApi";
import { Category, Product } from "../../types";
import { useParams } from 'react-router-dom';
import { ProductImage, CategoryImage } from "../../helpers/ImageFolder";

const Products: FC = () => {
    const [products, setProducts] = useState<Product[]>([]);
    const { categoryId } = useParams<{ categoryId: string }>();
    const [cates, setCate] = useState<Category | null>(null);
    const fetchCategoryImage = async () => {
        try {
            const link = categoryId !== undefined ? `${DotNetApi}category/id/${categoryId}` : "";
            const response = await axios.get<Category>(link);
            setCate(response.data);
        } catch (error) {
            console.log('There was an error!', error);
        } finally { }
    };
    const fetchProducts = async () => {
        const host = DotNetApi + 'product';
        const link = categoryId !== undefined ? host + '/categoryid/' + parseInt(categoryId, 10) : host;
        axios.get<Product[]>(link)
            .then(response => {
                setProducts(response.data);
            })
            .catch(
                error => {
                    console.error('There was an error!', error);
                },
            );
    };
    useEffect(() => {
        fetchCategoryImage();
        fetchProducts();
    }, [categoryId]);

    const categoryImage =
        <div className="">
            {cates ?
                <div key={cates.id}>
                    <img src={CategoryImage + cates.image} width="1000px" height="300px"></img>
                </div>
                : (
                    <div>
                        <p>No image found.</p>
                    </div>
                )}
        </div>

    const tableProducts =
        <div className="row rounded w-75 m-auto mt-5">
            {products.length > 0 ?
                products.map(product =>
                    <div className="col-6 col-sm-6 col-md-4 col-lg-4 col-xl-4 mt-4" key={product.id}>
                        <div className="border border-dark text-center w-90 my-3 mx-auto rounded">
                            <img src={ProductImage + product.image} className="w-100 rounded" height="150px" />
                            <h5>{product.name}</h5>
                            <h5>{product.price}$</h5>
                            <button className="btn btn-outline-primary mb-3">Detail</button>
                        </div>
                    </div>
                ) : (
                    <div>
                        <p>No product found.</p>
                    </div>
                )}
        </div>
    return (
        <div>
            {categoryImage}
            {tableProducts}
        </div>
    )
}

export default Products;
