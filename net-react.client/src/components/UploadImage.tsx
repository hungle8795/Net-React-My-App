import React, { useState } from 'react';
import axios from 'axios';
import { DotNetApi } from '../helpers/DotNetApi'; // Adjust the import according to your structure

const UploadImage: React.FC = () => {
    const [selectedFile, setSelectedFile] = useState<File | null>(null);
    const [imagePreview, setImagePreview] = useState<string | null>(null);
    const [loading, setLoading] = useState<boolean>(false);
    const [error, setError] = useState<string | null>(null);

    const handleFileChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        const file = event.target.files?.[0];
        if (file) {
            setSelectedFile(file);
            const anh = URL.createObjectURL(file)
            setImagePreview(anh); // Create a preview URL
            setError(null); // Clear any previous error
        }
    };

    const handleUpload = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        if (!selectedFile) {
            alert('Please select an image file first!');
            return;
        }

        const formData = new FormData();
        formData.append('image', selectedFile); // Append the file to the form data

        try {
            setLoading(true); // Start loading
            const response = await axios.post(`${DotNetApi}upload`, formData, {
                headers: {
                    'Content-Type': 'multipart/form-data', // Set the content type for file upload
                },
            });
            console.log(response.data);
            alert('Image uploaded successfully!');
            setSelectedFile(null); // Reset the selected file
            setImagePreview(null); // Reset the image preview
        } catch (err) {
            console.error('Error uploading image:', err);
            setError('Failed to upload image.'); // Set error message
        } finally {
            setLoading(false); // End loading
        }
    };

    return (
        <div className="container">
            <h2>Upload Image</h2>
            <form onSubmit={handleUpload}>
                <div className="mb-3">
                    <input
                        type="file"
                        accept="image/*"
                        onChange={handleFileChange}
                        required
                    />
                </div>
                {imagePreview && <img src={imagePreview} alt="Image Preview" className="img-preview mb-3" style={{ maxWidth: '50%', height: 'auto' }} />}
                <button type="submit" className="btn btn-primary" disabled={loading}>
                    {loading ? 'Uploading...' : 'Upload Image'}
                </button>
                {error && <p className="text-danger">{error}</p>} {/* Display error message */}
            </form>
        </div>
    );
};

export default UploadImage;



//import React, { useState } from 'react';
//import axios from 'axios';
//import { DotNetApi } from '../helpers/DotNetApi';

//const ImageUpload = () => {
//    const [selectedImage, setSelectedImage] = useState<File | null>(null);
//    const [imagePreview, setImagePreview] = useState<string | null>(null);
//    const [loading, setLoading] = useState<boolean>(false);
//    const [error, setError] = useState<string | null>(null);

//    const handleImageChange = (event: React.ChangeEvent<HTMLInputElement>) => {
//        if (event.target.files) {
//            const file = event.target.files?.[0];
//            setSelectedImage(event.target.files[0]);
//            setImagePreview(URL.createObjectURL(file)); // Create a preview URL
//            setError(null);
//        }
//    };

//    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
//        event.preventDefault();
//        if (selectedImage) {
//            const formData = new FormData();
//            formData.append('image', selectedImage);

//            try {
//                setLoading(true);
//                const response = await axios.post(DotNetApi + 'images/upload', formData, {
//                    headers: {
//                        'Content-Type': 'multipart/form-data',
//                    },
//                });
//                console.log(response.data);
//                alert('Image uploaded successfully!');
//                setSelectedImage(null); // Reset the selected file
//                setImagePreview(null);
//            } catch (error) {
//                console.error('Error uploading image:', error);
//            } finally {
//                setLoading(false);
//            }
//        }
//    };

//    return (
//        <form onSubmit={handleSubmit}>
//            <div className="mb-3">
//                <input type="file" accept="image/*" onChange={handleImageChange} required />
//            </div>
//            {imagePreview && <img src={imagePreview} alt="Image Preview" className="img-preview mb-3" style={{ maxWidth: '50%', height: 'auto' }} />}
//            <button type="submit" className="btn btn-primary" disabled={loading}>
//                {loading ? 'Uploading...' : 'Upload Image'}
//            </button>
//            {error && <p className="text-danger">{error}</p>} {/* Display error message */}
//        </form>
//    );
//};

//export default ImageUpload;