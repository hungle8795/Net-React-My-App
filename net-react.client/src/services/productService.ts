import axios from 'axios';
import { Product } from '../types/Product';

const API_URL = 'https://localhost:7006/api/product';

export const fetchProducts = async (): Promise<Product[]> => {
    const response = await axios.get(API_URL);
    return response.data;
};