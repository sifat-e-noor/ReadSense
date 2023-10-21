import * as React from 'react';
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import { deepPurple } from '@mui/material/colors';

export default function BasicTextFields() {
  return (
    <Box
      component="form"
      sx={{
        '& > :not(style)': { m: 1, width: '25ch' },
      }}
      noValidate
      autoComplete="off"
    >
      {/* <TextField id="outlined-basic" label="Outlined" variant="outlined" /> */}
      <TextField id="filled-basic" label="Email address" variant="filled" sx={{ borderColor: 'green', fontFamily: 'Nunito_Sans, Sans-serif' }}/>
      {/* <TextField id="standard-basic" label="Standard" variant="standard" /> */}
    </Box>
  );
}