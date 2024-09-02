import { useEffect, useState } from 'react';
import axiosInstance from '../../utils/axiosInstance';
import { PRODUCTS_LIST_URL } from '../../utils/globalConfig';
import { toast } from 'react-hot-toast';
import Spinner from '../../components/general/Spinner';
import { Product } from '../../types/product.types';
import moment from 'moment';

const ProductListPage = () => {
    const [products, setProducts] = useState<Product[]>([]);
  const [loading, setLoading] = useState<boolean>(false);

  const getProducts = async () => {
    try {
      setLoading(true);
        const response = await axiosInstance.get<Product[]>(PRODUCTS_LIST_URL);
      const { data } = response;
      setProducts(data);
      setLoading(false);
    } catch (error) {
      toast.error('An Error happened. Please Contact admins');
      setLoading(false);
    }
  };

  useEffect(() => {
    getProducts();
  }, []);

  if (loading) {
    return (
      <div className='w-full'>
        <Spinner />
      </div>
    );
  }

  return (
    <div className='pageTemplate2'>
      <h1 className='text-2xl font-bold'>Products List</h1>
      <div className='pageTemplate3 items-stretch'>
        <div className='grid grid-cols-8 p-2 border-2 border-gray-200 rounded-lg'>
          <span>Name</span>
          <span>Author</span>
          <span>Price</span>
          <span>Description</span>
          <span>Image</span>
          <span>Quality</span>
          <span>Color</span>
          <span>Date</span>
        </div>
        {products.map((item) => (
          <div className='grid grid-cols-8 p-2 border-2 border-gray-200 rounded-lg'>
            <span>{item.name}</span>
            <span>{item.userName}</span>
            <span>{item.price}</span>
            <span>{item.description}</span>
            <span>{item.image}</span>
            <span>{item.quality}</span>
            <span>{item.color}</span>
            <span>{moment(item.createdAt).fromNow()}</span>
          </div>
        ))}
      </div>
    </div>
  );
};

export default ProductListPage;
