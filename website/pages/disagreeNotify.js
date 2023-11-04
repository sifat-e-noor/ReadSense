import * as React from 'react';
import Button from '@mui/material/Button';
import { styled } from '@mui/material/styles';
import Dialog from '@mui/material/Dialog';
import DialogTitle from '@mui/material/DialogTitle';
import DialogContent from '@mui/material/DialogContent';
import DialogActions from '@mui/material/DialogActions';
import IconButton from '@mui/material/IconButton';
import CloseIcon from '@mui/icons-material/Close';
import Typography from '@mui/material/Typography';
import Image from 'next/image';
import Divider from '@mui/material/Divider';
import utilStyles from '../styles/utils.module.css';
import { Margin } from '@mui/icons-material';

const BootstrapDialog = styled(Dialog)(({ theme }) => ({
    '& .MuiDialogContent-root': {
        padding: theme.spacing(2),
    },
    '& .MuiDialogActions-root': {
        padding: theme.spacing(1),
    },
}));

export default function CustomizedDialogs() {
    const [open, setOpen] = React.useState(false);

    const handleClickOpen = () => {
        setOpen(true);
    };
    const handleClose = () => {
        setOpen(false);
    };

    return (
        <div>
            <Button variant="outlined" onClick={handleClickOpen}>
                Open dialog
            </Button>
            <BootstrapDialog
                onClose={handleClose}
                aria-labelledby="customized-dialog-title"
                open={open}
            >
                <DialogTitle
                    className={utilStyles.headingLg}
                    sx={{
                        textAlign: 'center',
                        fontFamily: 'Nunito_Sans, Sans-serif',
                        '& p': {
                            // color: 'red',
                            fontSize: '16px',
                            // fontWeight: 'bold', 
                            margin: '0px'
                        },
                    }} id="customized-dialog-title">
                    Hey reader!
                    <p >It looks like you haven’t agreed yet. Without your consent we can’t take you further in the ReadSense application.</p>
                </DialogTitle>
                <Divider light />
                <DialogContent style={{ paddingLeft: "9rem", paddingRight: "9rem", paddingTop: '1rem', paddingBottom: '2rem' }}>
                    <Image
                        src="/images/disagree.png"
                        width={300}
                        height={300}
                    // sizes="100vw"
                    // style={{ width: 'auto', height: 'auto' }} // optional
                    />
                </DialogContent>
            </BootstrapDialog>
        </div>
    );
}


