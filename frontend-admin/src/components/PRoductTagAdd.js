import { makeStyles } from '@mui/styles'
import React, { useEffect, useState } from 'react'

import { Navigate } from 'react-router-dom';
import { Button, Grid, Paper, TextField, Typography } from '@mui/material'
import { GET_ALL_CATEGORIES, GET_ALL_PRODUCTS, POST_ADD_PRODUCT } from '../api/apiService';
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
export default function ProductTagAdd() {
    const classes = useStyles()
    const [checkAdd, setCheckAdd] = useState(false)
    const [tag, setTag] = useState()
    const [tags, setTags] = useState({})
    const [pro, setPro] = useState()
    const [pros, setPros] = useState({})
    useEffect(() => {
        GET_ALL_CATEGORIES('Tag').then(item => {
            setTags(item.data)
        })
        GET_ALL_PRODUCTS('Product').then(item => {
            setPros(item.data)
        })
    }, [])


    const handleChangeCategory = (e) => {
        setTag(e.target.value)
    }
    const handleChangeProduct = (e) => {
        setPro(e.target.value)
    }
    const addProduct = (e) => {
        e.preventDefault()


        if (tag != null) {

            let product = {

                tagId: tag,
                productId: pro,
            }
            console.log("product adđ", product)
            POST_ADD_PRODUCT(`ProductTag`, product).then(item => {
                console.log("item", item)
                if (item.status === 201) {
                    setCheckAdd(true)

                }
            })
        }
        else {

            alert("Bạn chưa nhập đầy đủ thông tin!")
        }
    }

    if (checkAdd) {
        // return <Navigate to="/producttags" />

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
                                    Choose Tag
                                </Typography>
                                <TextField
                                    id="outlined-select-currency-native"
                                    name="tagId"
                                    select
                                    value={tag}
                                    onChange={handleChangeCategory}
                                    SelectProps={{
                                        native: true
                                    }}

                                    helperText="Please select your currency"
                                    variant="outlined"
                                    className={classes.txtInput}
                                >
                                    <option value="0">Choose tag</option>
                                    {tags.length > 0 &&
                                        tags.map((option) => (
                                            <option
                                                key={option.id}
                                                value={option.id}

                                            >
                                                {option.tagName}
                                            </option>
                                        ))}
                                </TextField>
                            </Grid>
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
                                    className={classes.txtInput}
                                >
                                    <option value="0">Choose Product</option>
                                    {pros.length > 0 &&
                                        pros.map((option) => (
                                            <option
                                                key={option.id}
                                                value={option.id}

                                            >
                                                {option.productName}
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
