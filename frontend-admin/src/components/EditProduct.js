import { makeStyles } from '@mui/styles'
import React, { useEffect, useState } from 'react'

import { Navigate, useParams } from 'react-router-dom';
import { Button, Grid, Paper, TextField, Typography } from '@mui/material'
import { GET_ALL_CATEGORIES, GET_PRODUCT_ID, PUT_EDIT_PRODUCT } from '../api/apiService';
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
        productName: {
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
const currencies = [
    {
        value: 'USD',
        label: '$'
    },
    {
        value: "EUR"
        , label: "€"
    },
    {
        value: "BTC",
        label: "b"
    },
    {
        value: 'JPY',
        label: 'y'
    }
]
export default function EditProduct({ match, location }) {
    const classes = useStyles()
    const { id } = useParams()
    const [checkUpdate, setCheckUpdate] = useState(false)
    const [idProduct, setIdProduct] = useState(0)
    const [productName, setTitle] = useState(null)
    const [salePrice, setBody] = useState(null)
    const [buyingPrice, setSlug] = useState(null)
    const [category, setCategory] = useState()
    const [productCategoryNames, setProductCategoryNames] = useState(null)
    const [categories, setCategories] = useState({})
    console.log(id)
    useEffect(() => {
        GET_PRODUCT_ID(`Product`, id).then(product => {
            console.log(product)
            setIdProduct(product.data.id)
            setTitle(product.data.productName);
            setSlug(product.data.buyingPrice);
            setBody(product.data.salePrice); // Set the salePrice from the response

            setCategory(product.data.productCategoryIds[0]);
        })
        GET_ALL_CATEGORIES('Categories').then(item => {
            setCategories(item.data)
        })
    }, [])
    const handleChangeTitle = (e) => {
        setTitle(e.target.value)
    }
    const handleChangeBody = (e) => {
        setBody(e.target.value)
    }
    const handleChangeSlug = (e) => {
        setSlug(e.target.value)
    }

    const handleChangeCategory = (e) => {
        setCategory(e.target.value)
    }
    const editProduct = async (e) => {
        e.preventDefault()

        if (productName !== "" && salePrice >= 0 && buyingPrice >= 0 && category != null) {
            const salePriceNumber = parseFloat(salePrice);
            const buyingPriceNumber = parseFloat(buyingPrice);
            const product = {
                productName: productName,
                salePrice: salePriceNumber,
                buyingPrice: buyingPriceNumber,
                productCategoryIds: [category],
                productCategoryNames: [
                    ""
                ],
            };

            try {
                const editedProduct = await PUT_EDIT_PRODUCT(`Product/${id}`, product);
                console.log(editProduct)
                if (editedProduct.status === 204) {
                    setCheckUpdate(true);
                }

                // if (editedProduct.status === 200) {
                // } else {
                //   alert('Bạn chưa nhập đủ thông tin!');
                // }
            } catch (error) {
                console.error('Error editing product:', error);
            }
        }

    }

    if (checkUpdate) {
        return <Navigate to="/" />
    }
    return (
        <div className={classes.root}>
            <Grid container spacing={3}>
                <Grid item xs={12}>
                    <Paper className={classes.paper}>
                        <Typography className={classes.productName} variant="h4">
                            Add Product
                        </Typography>
                        <Grid container spacing={3}>
                            <Grid item xs={12}>
                                <Typography gutterBottom variant="subtitle1">
                                    Title
                                </Typography>
                                <TextField
                                    id="productName"
                                    onChange={handleChangeTitle}
                                    name="productName"

                                    variant="outlined"
                                    className={classes.txtInput}
                                    size="small"
                                    value={productName}
                                />
                            </Grid>
                            <Grid item xs={12}>
                                <Typography gutterBottom variant="subtitle1">
                                    Sale Price
                                </Typography>
                                <TextField
                                    id="outlined-multiline-static"
                                    onChange={handleChangeBody}

                                    name="Body"
                                    className={classes.txtInput}
                                    type="number"
                                    value={salePrice}
                                    variant="outlined"
                                />
                            </Grid>
                            <Grid item xs={12}>
                                <Typography gutterBottom variant="subtitle1">
                                    Buying Price
                                </Typography>
                                <TextField
                                    id="outlined-multiline-static"
                                    onChange={handleChangeSlug}

                                    name="Slug"
                                    className={classes.txtInput}
                                    type="number"

                                    value={buyingPrice}
                                    variant="outlined"
                                />
                            </Grid>

                            <Grid item xs={12}>
                                <Typography gutterBottom variant="subtitle1">
                                    Choose Category
                                </Typography>
                                <TextField
                                    id="outlined-select-currency-native"
                                    name="idCategory"
                                    select
                                    value={category}
                                    onChange={handleChangeCategory}
                                    SelectProps={{
                                        native: true,
                                    }}
                                    defaultChecked
                                    helperText="Please select your currency"
                                    variant="outlined"
                                    className={classes.txtInput}
                                >
                                    <option value="0">Choose category</option>
                                    {categories.length > 0 &&
                                        categories.map((option) => (

                                            < option
                                                key={option.id}
                                                value={option.id}

                                            >
                                                {option.categoryName}
                                                {console.log(categories)}
                                            </option>
                                        ))}
                                </TextField>
                            </Grid>
                            <Grid item xs={12}>
                                <Button
                                    type="button"
                                    onClick={editProduct}
                                    className={classes.submit}
                                    fullWidth
                                    variant="contained"
                                    color="primary"
                                >
                                    Update Product
                                </Button>
                            </Grid>
                        </Grid>
                    </Paper>
                </Grid>
            </Grid >
        </div >

    )
}
