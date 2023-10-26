import Head from 'next/head';
import Image from 'next/image';
import styles from './layout.module.css';
import utilStyles from '../styles/utils.module.css';
import Link from 'next/link';
import Stack from '@mui/material/Stack';
import * as React from 'react';
import PropTypes from 'prop-types';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import CssBaseline from '@mui/material/CssBaseline';
import useScrollTrigger from '@mui/material/useScrollTrigger';
import Box from '@mui/material/Box';
import Container from '@mui/material/Container';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import { Add , AddRounded, ArrowBackIosNewRounded, BackHandRounded, RemoveRounded} from '@mui/icons-material';
import BasicTextFields from '../components/textfield';
import NumberInput from './NumberInput';
import CustomRadioChip from './CustomRadioChip';
import Input from './input';
import AlignmentToggle from './toggleButton';
import FormatAlignLeftIcon from '@mui/icons-material/FormatAlignLeft';
import FormatAlignCenterIcon from '@mui/icons-material/FormatAlignCenter';
import FormatAlignRightIcon from '@mui/icons-material/FormatAlignRight';
import FormatAlignJustifyIcon from '@mui/icons-material/FormatAlignJustify';
import ViewWeekOutlinedIcon from '@mui/icons-material/ViewWeekOutlined';
import TableRowsOutlinedIcon from '@mui/icons-material/TableRowsOutlined';
import ToggleButton from '@mui/material/ToggleButton';

// const name = 'Sifat-E-Noor';
export const siteTitle = 'ReadSense - Personalized Reading Experience App ';

function ElevationScroll(props) {
  const { children, window } = props;
  // Note that you normally won't need to set the window ref as useScrollTrigger
  // will default to window.
  // This is only being set here because the demo is in an iframe.
  const trigger = useScrollTrigger({
    disableHysteresis: true,
    threshold: 0,
    target: window ? window() : undefined,
  });

  return React.cloneElement(children, {
    elevation: trigger ? 0 : 0,
  });
}

ElevationScroll.propTypes = {
  children: PropTypes.element.isRequired,
  /**
   * Injected by the documentation to work in an iframe.
   * You won't need it on your project.
   */
  window: PropTypes.func,
};


export default function Layout(props) {

  const [fonttype, setFonttype] = React.useState(undefined);

  const fonttypekRadioButtonFields = [
    { label: 'Sans-serif', value: 'sans-serif' },
    { label: 'Serif', value: 'serif' },
  ];
  
  const handleClick = () => {
    console.info('You clicked the Chip.');
  };

    return (
      <React.Fragment>
        <CssBaseline />
        <ElevationScroll {...props}>
          <AppBar sx={{ backgroundColor: 'transparent'}}>
            {/* <div className={styles.logoHeader}>
              <Image
                priority
                src="/images/smallLogo.png"
                // className={utilStyles.borderCircle}
                height={0}
                width={0}
                sizes="100vw"
                style={{ width: 'auto', height: 'auto'}} // optional
                alt=""
              />
            </div> */}
            {/* <div className={styles.header}> */}
            <Toolbar component='div' variant="dense" className={styles.toolBar}>  
              <div className={styles.leftHeader}> 
                <div className={styles.smallBox}>
                  <Stack spacing={.5} direction="row" alignItems={'center'}>
                    <IconButton edge="start" color="inherit" aria-label="backArrow" sx={{ mr: 2 }}>
                      <ArrowBackIosNewRounded className={styles.logoColor}/>
                    </IconButton>
                    <Typography variant="h6" component='div' className={styles.backText}>
                      Back
                    </Typography>
                  </Stack>
                </div>
              </div>
              <div className={styles.rightHeader}> 
                <div className={styles.largeBox}>
                  <Stack spacing={3} direction="row" useFlexGap flexWrap="wrap" justifyContent='center' alignItems='center'>
                    <Stack spacing={.5} direction="column">
                      {/* <Stack spacing={2} direction="row"> */}
                        <NumberInput />      
                      {/* </Stack> */}
                      <Typography variant="h6" component='div' className={styles.HeaderLabel}>Font size</Typography>
                    </Stack>
                    <Stack spacing={.5} direction="column">
                      <Stack spacing={.5} direction="row">
                        <CustomRadioChip 
                          handleClick = {setFonttype}
                          selected = {fonttype}
                          fields = {fonttypekRadioButtonFields}
                        />
                      </Stack>
                      <Typography variant="h6" component='div' className={styles.HeaderLabel}>Font type</Typography>
                    </Stack>
                    <Stack spacing={.5} direction="column">
                      <Stack spacing={1} direction="row" alignItems={'center'}>
                        < Image
                        src="/images/format_letter_spacing_wider.png"
                        width={0}
                        height={0}
                        sizes="100vw"
                        style={{ width: '28px', height: '30px' }} // optional
                        />
                        <Input type="text"/>
                      </Stack>
                      <Typography variant="h6" component='div' className={styles.HeaderLabel}>Letter spacing</Typography>
                    </Stack>
                    <Stack spacing={.5} direction="column">
                      <Stack spacing={1} direction="row" alignItems={'center'}>
                        < Image
                        src="/images/letter_height.png"
                        width={0}
                        height={0}
                        sizes="100vw"
                        style={{ width: '28px', height: '30px' }} // optional
                        />
                        <Input type="text"/>
                      </Stack>
                      <Typography variant="h6" component='div' className={styles.HeaderLabel}>Line height</Typography>
                    </Stack>
                    <Stack spacing={.5} direction="column">
                      <Stack spacing={1} direction="row" alignItems={'center'}>
                        < AlignmentToggle>
                          <ToggleButton value="column" aria-label="column text">
                            <ViewWeekOutlinedIcon />
                          </ToggleButton>
                          <ToggleButton value="row" aria-label="row text">
                            <TableRowsOutlinedIcon />
                          </ToggleButton>
                        </AlignmentToggle>
                      </Stack>
                      <Typography variant="h6" component='div' className={styles.HeaderLabel}>Layout</Typography>
                    </Stack>
                    <Stack spacing={.5} direction="column">
                      <Stack spacing={1} direction="row" alignItems={'center'}>
                      < AlignmentToggle>
                          <ToggleButton value="left" aria-label="left aligned">
                            <FormatAlignLeftIcon />
                          </ToggleButton>
                          <ToggleButton value="justify" aria-label="justified">
                            <FormatAlignJustifyIcon />
                          </ToggleButton>
                          <ToggleButton value="right" aria-label="right aligned">
                            <FormatAlignRightIcon />
                          </ToggleButton>
                        </AlignmentToggle>
                      </Stack>
                      <Typography variant="h6" component='div' className={styles.HeaderLabel}>Alignment</Typography>
                    </Stack>
                  </Stack>
                </div>
              </div> 
            </Toolbar>
          </AppBar>
        </ElevationScroll>
        {/* <Toolbar /> */}
        {props.children}
      </React.Fragment>
    );
  }




{/* <div className={styles.largeBox}>
              <IconButton edge="start" color="inherit" aria-label="menu" sx={{ mr: 2 }}>
                  <ArrowBackIosNewRounded className={styles.backLogo}/>
                </IconButton>
                <Typography variant="h6" component='div' className={styles.backText}>
                  Back
                </Typography>
                {/* <Stack spacing={2} direction="row">

                </Stack> */}
              // </div> */}