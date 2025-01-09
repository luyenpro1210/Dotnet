import React, { useEffect, useState } from 'react';
import { makeStyles } from '@mui/styles';
import Paper from '@mui/material/Paper';
import Grid from '@mui/material/Grid';
import Alert from '@mui/material/Alert';
import IconButton from '@mui/icons-material/IosShare';
import CloseIcon from '@mui/icons-material/IosShare';
import Button from '@mui/material/Button';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import { Link } from 'react-router-dom';
import { DELETE_TAG_ID, GET_ALL_TAG } from '../../api/apiService';
const useStyles = makeStyles((theme) => ({
    root: {
        flexGrow: 1,
        marginTop: 20,
    },
    paper: {
        width: "100%",
        margin: "auto",
    },
    removeLink: {
        textDecoration: "none",
    }
}));
export default function Index() {
    const classes = useStyles();
    const [tag, setTag] = useState({});
    const [checkDeleteTag, setCheckDeleteTag] = useState(false);
    const [setClose] = React.useState(false);

    useEffect(() => {
        GET_ALL_TAG(`Tag`).then(item => 
            setTag(item.data));
    }, [])

    const deleteTagID = (id) => {
        DELETE_TAG_ID(`Tag/${id}`).then(item => {
            console.log(item)
            if (item.data === 1) {
                setCheckDeleteTag(true);
                setTag(tag.filter(key => key.id !== id));
            }
        })
    }
    return (
        <div className={classes.root}>
            <Grid container spacing={3}>
                <Grid item xs={12}>
                    <Paper className={classes.paper}>
                        {checkDeleteTag && <Alert
                            action={
                                <IconButton
                                    aria-label="close"
                                    color="inherit"
                                    size="small"
                                    onClick={() => {
                                        setClose(true);
                                        setCheckDeleteTag(false)
                                    }}
                                >
                                    <CloseIcon fontSize="inherit" />
                                </IconButton>
                            }
                        > Delete successfully</Alert>}
                        <TableContainer component={Paper}>
                            <Table className={classes.table} aria-label="simple table">
                                <TableHead>
                                    <TableRow>
                                        <TableCell><b>Tag Name</b></TableCell>
                                        <TableCell align="center"><b>Icon</b></TableCell>
                                        <TableCell align="center"><b>CreateAt</b></TableCell>
                                        <TableCell align="center"><b>Edit</b></TableCell>
                                        <TableCell align="center"><b>Delete</b></TableCell>
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    {tag.length > 0 && tag.map((row) => (
                                        <TableRow key={row.id}>
                                            <TableCell component="th" scope="row">{row.tag_name}</TableCell>
                                            <TableCell align="center">{row.icon}</TableCell>
                                            <TableCell align="center">{row.created_at}</TableCell>
                                            <TableCell align="center">
                                                <Link to={`/admin/edittags/${row.id}`} className={classes.removeLink}>
                                                    <Button size="small" variant="contained" color="primary">Edit</Button></Link>
                                            </TableCell>
                                            <TableCell align="center">
                                                <Button size="small" variant="contained" color="secondary"
                                                    onClick={() => deleteTagID(row.id)}>Remove</Button>
                                            </TableCell>
                                        </TableRow>
                                    ))}
                                </TableBody>
                            </Table>
                        </TableContainer>
                    </Paper>
                </Grid>
            </Grid>
        </div>
    )
}