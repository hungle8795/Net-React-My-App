import { useState } from 'react';
import { CREATE_PRODUCT_URL } from '../../utils/globalConfig';
import axiosInstance from '../../utils/axiosInstance';
import { toast } from 'react-hot-toast';
import Spinner from '../../components/general/Spinner';
import * as Yup from 'yup';
import { useForm } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';
import InputField from '../../components/general/InputField';
import FileField from '../../components/general/FileField';
import Button from '../../components/general/Button';
import { useNavigate } from 'react-router-dom';
import { PATH_DASHBOARD } from '../../routes/paths';
import { IAddNewProductDto } from '../../types/product.types';

const AddProductPage = () => {
    const [loading, setLoading] = useState<boolean>(false);
    const navigate = useNavigate();

    const onSubmitAddProductForm = async (addNewProduct: IAddNewProductDto) => {
      try {
        setLoading(true);
        const newProduct: IAddNewProductDto = {
          name: addNewProduct.name,
          image: addNewProduct.image,
          color: addNewProduct.color,
          description: addNewProduct.description,
          price: addNewProduct.price,
          quality: addNewProduct.quality,
        };

        await axiosInstance.post(CREATE_PRODUCT_URL, newProduct);
        setLoading(false);
        toast.success('Add new product successfully.');
        navigate(PATH_DASHBOARD.productList);
      } catch (error) {
          setLoading(false);
          reset();
          const err = error as { data: string; status: number };
          if (err.status === 400) {
            toast.error(err.data);
          } else {
            toast.error('An Error occurred. Please contact admins');
          }
      }
    };

    const addProductSchema = Yup.object().shape({
        name: Yup.string().required('Product Name is required'),
        image: Yup.string().required('Product Image is required'),
        color: Yup.string().required('Product Color is required'),
        description: Yup.string().required('Product Description is required'),
        price: Yup.number().required('Product Price is required'),
        quality: Yup.number().required('Product Quantity is required'),
      });
    
      const {
        control,
        handleSubmit,
        formState: { errors },
        reset,
      } = useForm<IAddNewProductDto>({
        resolver: yupResolver(addProductSchema),
        defaultValues: {
          name: '',
          image: '',
          color: '',
          description: '',
          price: 0,
          quality: 0,
        },
      });

    if (loading) {
        return (
            <div className='w-full'>
            <Spinner />
            </div>
        );
    }
    return (
        <div className='pageTemplate2'>
          <h1 className='text-2xl font-bold'>Add New Product</h1>
          <div className='pageTemplate3 items-stretch'>
          <form onSubmit={handleSubmit(onSubmitAddProductForm)}>
              <h1 className='text-4xl font-bold mb-2 text-[#754eb4]'>Add New Product</h1>
              <InputField control={control} label='Name' inputName='name' error={errors.name?.message} />
              <FileField control={control}  label='Image' inputName='file' />
              <InputField control={control} label='Color' inputName='color' error={errors.color?.message} />
              <InputField control={control} label='Description' inputName='description' error={errors.description?.message} />
              <InputField control={control} label='Price' inputName='price' error={errors.price?.message} />
              <InputField control={control} label='Quality' inputName='quality' error={errors.quality?.message} />
              <div className='flex justify-center items-center gap-4 mt-6'>
              <Button variant='primary' type='submit' label='Add' onClick={() => {}} loading={loading} />
              </div>
            </form>
          </div>
        </div>
      );
    };
export default AddProductPage;