import { makeStyles } from '@mui/styles'
import React, { useEffect, useState } from 'react'

import { Navigate } from 'react-router-dom';
import { Button, Grid, Paper, TextField, Typography } from '@mui/material'
import { GET_ALL_PRODUCTS, POST_ADD_PRODUCT, uploadMultipleImages } from '../api/apiService';
const useStyles = makeStyles((theme) => {
    const spacing = (value) => `${value * 8}px`; // Define your custom spacing function

    return {
        root: {
            flexGrow: 1,
            marginTop: spacing(2), // Use the custom spacing function
        },
        paper: {
            padding: spacing(2),
            maxWidth: 600,
            margin: 'auto',
        },
        title: {
            fontSize: 30,
            textAlign: 'center',
        },
        link: {
            padding: spacing(1),
            display: 'inline-block',
        },
        txtInput: {
            width: '98%',
            margin: spacing(1),
        },
        submit: {
            margin: `${spacing(3)} 0 ${spacing(2)}`,
        },
    };
});
export default function Gallery() {
    const classes = useStyles()
    const [images, setImages] = useState([]);
    const [tag, setTag] = useState(null);
    const [pros, setPros] = useState([]);
    const [pro, setPro] = useState('');
    const [IsThumbnail, setIsThumbnail] = useState(false);
    const [checkAdd, setCheckAdd] = useState(false);

    useEffect(() => {
        GET_ALL_PRODUCTS('Product').then(item => {
            setPros(item.data);
        });
    }, []);

    const handleImageChange = (e) => {
        setImages([...images, ...e.target.files]);
    };

    const handleChangeProduct = (e) => {
        setPro(e.target.value);
    };

    const addProduct = (e) => {
        e.preventDefault();

        if (pro && images.length > 0) {
            const productId = pro;
            const isThumbnail = false; // Assuming isThumbnail is always false for now
            const endpoint = 'Gallery/multiple'; // Update the endpoint as needed

            uploadMultipleImages(endpoint, productId, isThumbnail, images)
                .then((item) => {
                    if (item.status === 200) {
                        setCheckAdd(true);
                    }
                })
                .catch((error) => {
                    console.error('Error:', error);
                    // Handle error
                });
        } else {
            alert('Vui lòng điền đầy đủ thông tin và chọn ít nhất một hình ảnh!');
        }
    };
    if (checkAdd) {
        return <Navigate to="/" />;
    }

    return (
        <div className={classes.root}>
            <Grid container spacing={3}>
                <Grid item xs={12}>
                    <Paper className={classes.paper}>
                        <Typography className={classes.title} variant="h4">
                            Add Gallery
                        </Typography>

                        <Grid container spacing={2}>
                            <Grid item xs={12}>
                                <Typography gutterBottom variant="subtitle1">
                                    Choose Product
                                </Typography>
                                <TextField
                                    id="outlined-select-currency-native"
                                    name="productId"
                                    select
                                    value={pro}
                                    onChange={handleChangeProduct}
                                    SelectProps={{
                                        native: true
                                    }}
                                    helperText="Please select your currency"
                                    variant="outlined"
                                    fullWidth
                                >
                                    <option value="0">Choose Product</option>
                                    {pros.map((option) => (
                                        <option key={option.id} value={option.id}>
                                            {option.productName}
                                        </option>
                                    ))}
                                </TextField>
                            </Grid>
                            <Grid item xs={12}>
                                <Typography gutterBottom variant="subtitle1">
                                    Choose Images
                                </Typography>
                                <input type="file" onChange={handleImageChange} multiple />
                                {images.map((image, index) => (
                                    <img key={index} src={URL.createObjectURL(image)} alt={`Preview ${index}`} style={{ width: '100px', height: '100px', margin: '10px' }} />
                                ))}
                            </Grid>
                            <Grid item xs={12}>
                                <Button
                                    type="button"
                                    onClick={addProduct}
                                    fullWidth
                                    variant="contained"
                                    color="primary"
                                >
                                    Add product
                                </Button>
                            </Grid>
                        </Grid>
                    </Paper>
                </Grid>
            </Grid>
        </div>
    );
}
