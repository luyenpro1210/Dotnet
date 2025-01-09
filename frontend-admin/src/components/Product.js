import { makeStyles } from '@mui/styles'
import React, { useEffect, useState } from 'react'

import { Navigate } from 'react-router-dom';
import { Button, Grid, Paper, TextField, Typography } from '@mui/material'
import { GET_ALL_CATEGORIES, POST_ADD_PRODUCT } from '../api/apiService';
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
export default function Product() {
    const classes = useStyles()
    const [checkAdd, setCheckAdd] = useState(false)
    const [productName, setTitle] = useState(null)
    const [body, setBody] = useState(0)
    const [slug, setSlug] = useState(0)
    const [category, setCategory] = useState()
    const [productCategoryNames, setProductCategoryNames] = useState(null)
    const [categories, setCategories] = useState({})
    useEffect(() => {
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

    const addProduct = (e) => {
        e.preventDefault()


        if (productName !== "" && body >= 0 && slug >= 0 && category != null) {
            const salePriceNumber = parseFloat(body);
            const buyingPriceNumber = parseFloat(slug);
            console.log("productName", productName)
            console.log("salePrice", salePriceNumber)
            console.log("buyingPrice", buyingPriceNumber)
            console.log("productCategoryIds", category)

            let product = {
                productName: productName,
                salePrice: salePriceNumber,
                buyingPrice: buyingPriceNumber,
                productCategoryIds: [
                    category
                ],
                productCategoryNames: [
                    ""
                ],
            }
            console.log("product adđ", product)
            POST_ADD_PRODUCT(`Product`, product).then(item => {
                console.log("item", item)
                if (item.status === 201) {
                    setCheckAdd(true)
                }
            })
        }
        else {
            console.log("productName", productName)
            console.log("salePrice", body)
            console.log("buyingPrice", slug)
            console.log("productCategoryIds", category)
            alert("Bạn chưa nhập đầy đủ thông tin!")
        }
    }

    if (checkAdd) {
        return <Navigate to="/" />
    }
    return (
        <div className={classes.root}>
            <Grid container spacing={3}>
                <Grid item xs={12}>
                    <Paper className={classes.paper}>
                        <Typography className={classes.title} variant="h4">
                            Add Product
                        </Typography>
                        <Grid container spacing={3}>
                            <Grid item xs={12}>
                                <Typography gutterBottom variant="subtitle1">
                                    Title
                                </Typography>
                                <TextField
                                    id="Title"
                                    onChange={handleChangeTitle}
                                    name="Title"

                                    variant="outlined"
                                    className={classes.txtInput}
                                    size="small"
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
                                    type="number"
                                    className={classes.txtInput}
                                    multiline
                                    size="small"

                                    variant="outlined"
                                />
                            </Grid>
                            <Grid item xs={12}>
                                <Typography gutterBottom variant="subtitle1">
                                    Buying Price
                                </Typography>
                                <TextField
                                    id="Slug"
                                    onChange={handleChangeSlug}
                                    name="Slug"
                                    type="number"
                                    variant="outlined"
                                    className={classes.txtInput}
                                    size="small"
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
                                        native: true
                                    }}

                                    helperText="Please select your currency"
                                    variant="outlined"
                                    className={classes.txtInput}
                                >
                                    <option value="0">Choose category</option>
                                    {categories.length > 0 &&
                                        categories.map((option) => (
                                            <option
                                                key={option.id}
                                                value={option.id}

                                            >
                                                {option.categoryName}
                                            </option>
                                        ))}
                                </TextField>
                            </Grid>
                            <Grid item xs={12}>
                                <Button
                                    type="button"
                                    onClick={addProduct}
                                    className={classes.submit}
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

    )
}
