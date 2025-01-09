import { makeStyles } from '@mui/styles'
import React, { useEffect, useState } from 'react'

import { Navigate } from 'react-router-dom';
import { Button, Grid, Paper, TextField, Typography } from '@mui/material'
import { GET_ALL_CATEGORIES, POST_ADD_CATEGORY, postCategory } from '../api/apiService'; // Import your API service function for adding a category
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
export default function CategoryAdd() {
    const classes = useStyles()
    const [categoryData, setCategoryData] = useState({
        parentId: '',
        categoryName: '',
        categoryDescription: '',
        icon: '',
        placeholder: '',
        active: true
    });

    const [svgFile, setSvgFile] = useState(null);
    const [error, setError] = useState('');

    const handleChange = (e) => {
        setCategoryData({ ...categoryData, [e.target.name]: e.target.value });
    };

    const handleFileChange = (e) => {
        setSvgFile(e.target.files[0]);
    };
    const [categories, setCategories] = useState({})
    useEffect(() => {
        GET_ALL_CATEGORIES('Categories').then(item => {
            setCategories(item.data)
        })
    }, [])
    const handleSubmit = async (e) => {
        e.preventDefault();

        try {

            const formData = new FormData();
            formData.append('ParentId', categoryData.parentId);
            formData.append('CategoryName', categoryData.categoryName);
            formData.append('CategoryDescription', categoryData.categoryDescription);
            formData.append('Icon', categoryData.icon);
            formData.append('Placeholder', categoryData.placeholder);
            formData.append('Active', categoryData.active);
            formData.append('svgFile', svgFile);

            const response = await POST_ADD_CATEGORY(formData);
            // Call your API service function to add the category

            // Handle success response
            console.log('Category added successfully:', response);

            // Clear form fields or redirect to another page
            setCategoryData({
                parentId: '',
                categoryName: '',
                categoryDescription: '',
                icon: '',
                placeholder: '',
                active: true
            });
            setSvgFile(null);
            setError('');
        } catch (error) {
            // Handle error
            console.error('Error adding category:', error);
            setError('Error adding category. Please try again later.');
        }
    };
    const handleChangeCategory = (e) => {
        setCategoryData({ ...categoryData, parentId: e.target.value })
    }
    return (

        <div className={classes.root}>
            <Grid container spacing={3}>
                <Grid item xs={12}>
                    <Paper className={classes.paper}>
                        <Typography className={classes.title} variant="h4">
                            Add Category
                        </Typography>
                        <Grid container spacing={2}>
                            <Grid item xs={12}>
                                <Paper>
                                    <form onSubmit={handleSubmit}>
                                        <Grid item xs={12}>
                                            <Typography gutterBottom variant="subtitle1">
                                                Choose Category
                                            </Typography>
                                            <TextField
                                                id="outlined-select-currency-native"
                                                name="idCategory"
                                                select
                                                value={categoryData.parentId}
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
                                            <Typography gutterBottom variant="subtitle1">
                                                Title
                                            </Typography>
                                            <TextField
                                                id="Title"
                                                onChange={handleChange}
                                                name="categoryName"
                                                value={categoryData.categoryName}

                                                className={classes.txtInput}
                                                fullWidth
                                                margin="normal"
                                            />
                                        </Grid>
                                        <Grid item xs={12}>
                                            <Typography gutterBottom variant="subtitle1">
                                                Description
                                            </Typography>
                                            <TextField
                                                id="Description"
                                                onChange={handleChange}
                                                name="categoryDescription"
                                                value={categoryData.categoryDescription}

                                                className={classes.txtInput}
                                                fullWidth
                                                margin="normal"
                                            />
                                        </Grid>
                                        <Grid item xs={12}>
                                            <Typography gutterBottom variant="subtitle1">
                                                Icon
                                            </Typography>
                                            <TextField
                                                id="Icon"
                                                onChange={handleChange}
                                                name="icon"
                                                value={categoryData.icon}

                                                className={classes.txtInput}
                                                fullWidth
                                                margin="normal"
                                            />
                                        </Grid>
                                        <Grid item xs={12}>
                                            <Typography gutterBottom variant="subtitle1">
                                                placeholder
                                            </Typography>
                                            <TextField
                                                id="placeholder"
                                                onChange={handleChange}
                                                name="placeholder"
                                                value={categoryData.placeholder}

                                                className={classes.txtInput}
                                                fullWidth
                                                margin="normal"
                                            />
                                        </Grid>
                                        <Grid item xs={12}>
                                            <Typography gutterBottom variant="subtitle1">
                                                Active
                                            </Typography>
                                            <TextField
                                                name="active"

                                                value={categoryData.active}
                                                onChange={handleChange}
                                                fullWidth
                                                margin="normal"
                                                type="checkbox"
                                                InputProps={{
                                                    inputProps: {
                                                        min: 0
                                                    }
                                                }}
                                                style={{ width: "5%" }}
                                            />

                                        </Grid>
                                        <Grid item xs={12}>
                                            <Typography gutterBottom variant="subtitle1">
                                                Image
                                            </Typography>
                                            <input type="file" name="svgFile" onChange={handleFileChange} />

                                        </Grid>





                                        <Button type="submit" variant="contained" color="primary">
                                            Add Category
                                        </Button>
                                        {error && <Typography color="error">{error}</Typography>}
                                    </form>
                                </Paper>
                            </Grid>
                        </Grid>
                    </Paper>
                </Grid>
            </Grid>
        </div>
    );
}
