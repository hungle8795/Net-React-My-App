import axios from 'axios';
import { DotNetApi } from '../helpers/DotNetApi';
import { Product } from '../types';

export const fetchProducts = async (): Promise<Product[]> => {
    const response = await axios.get(DotNetApi + 'product');
    return response.data;
};