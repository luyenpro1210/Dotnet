import React, { useEffect, useState } from 'react';
import axios from 'axios';
import baseURL from '../../api/BaseUrl';

function ImageProductShow({ id, name }) {
    const [images, setImages] = useState([]);


    useEffect(() => {
        // Gọi API để lấy danh sách hình ảnh khi component được render
        axios.get(baseURL + `Gallery/by-product/` + id)
            .then(response => {

                setImages(response.data);
            })
            .catch(error => {
                console.error('Error fetching images:', error);
            });
    }, [id]);

    // Kiểm tra xem images có dữ liệu không trước khi truy cập images.image
    if (!images || images.length === 0) {
        return <img src={require("../../assets/images/No_Image-1024.png")} alt="No_Image-1024" className="showcase-img" />;
    }

    return (
        <div>
            {/* Render img khi images đã được thiết lập */}
            <img src={`data:image/jpg;base64,${images[0].image}`} alt={name} className="showcase-img" />

        </div>
    );
}

export default ImageProductShow;
