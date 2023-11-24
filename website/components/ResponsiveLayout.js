import * as React from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import Menu from '@mui/material/Menu';
import MenuIcon from '@mui/icons-material/Menu';
import Container from '@mui/material/Container';
import CssBaseline from '@mui/material/CssBaseline';
import Stack from '@mui/material/Stack';
import PropTypes from 'prop-types';
import ToggleButton from '@mui/material/ToggleButton';
import FormatAlignLeftIcon from '@mui/icons-material/FormatAlignLeft';
import FormatAlignRightIcon from '@mui/icons-material/FormatAlignRight';
import FormatAlignJustifyIcon from '@mui/icons-material/FormatAlignJustify';
import ViewWeekOutlinedIcon from '@mui/icons-material/ViewWeekOutlined';
import TableRowsOutlinedIcon from '@mui/icons-material/TableRowsOutlined';
import Image from 'next/image';
import styles from './layout.module.css';
import { useRouter } from 'next/router';
import Toolbar from '@mui/material/Toolbar';
import useScrollTrigger from '@mui/material/useScrollTrigger';
import IconButton from '@mui/material/IconButton';
import { Add , AddRounded, ArrowBackIosNewRounded, BackHandRounded, RemoveRounded} from '@mui/icons-material';
import NumberInput from './NumberInput';
import CustomRadioChip from './CustomRadioChip';
import Input from './input';
import AlignmentToggle from './toggleButton';
import { getFontSize, setFontSize, getFonts, setFonts, getLineHeight, setLineHeight, getLineSpacing, setLineSpacing, getAlign, setAlign, getLayout, setLayout } from  "../redux/readerSlice";
import{useSelector, useDispatch}from  "react-redux";

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

const CustomTextInputForNumber = (props) => {
    const [inputValue, setInputValue] = React.useState(props.value);

    React.useEffect(() => {
        const handler = setTimeout(() => {
        if (typeof props.changeHandler === 'function') {
            
            var value = undefined;
            if (props.type === 'int') {
            value = parseInt(inputValue);
            } else if (props.type === 'float') {
            value = parseFloat(inputValue);
            } else {
            value = inputValue;
            }
            if (isNaN(value) || value < props.min || value > props.max || value === props.value) {
            setInputValue(props.value);
            return;
            }
            if (props.type === 'float') {
            var multiplier = Math.pow(10, 1);
            value =  (Math.round(value * multiplier) / multiplier).toFixed(1);
            }
            if(props.value == value) {
            setInputValue(value);
            } else {
            props.changeHandler(value);
            }
        }
        }, 1000);

        return () => {
        clearTimeout(handler);
        };
    }, [inputValue, props.changeHandler]);

    React.useEffect(() => {
        setInputValue(props.value);
    }, [props.value]);

    return (
        <Input type="text" value={inputValue} changeHandler={setInputValue}/>
    )
}

function ResponsiveLayout(props) {
    const [anchorElNav, setAnchorElNav] = React.useState(null);

    const router = useRouter();
    const dispatch = useDispatch();
    const fontSize = useSelector(getFontSize);
    const fonts = useSelector(getFonts);
    const lineHeight = useSelector(getLineHeight);
    const lineSpacing = useSelector(getLineSpacing);
    const alignment = useSelector(getAlign);
    const layout = useSelector(getLayout);

    const handleBackButtonClick = () => {
        router.push('/existingUserPickStory');
    };

    const handleFontSizeChange = (data) => {
        dispatch(setFontSize(data));
      };
    
      const setFonttype = (data) => {
        dispatch(setFonts(data));
      }
    
      const handleLineHeightChange = (data) => {
        dispatch(setLineHeight(data));
      }
    
      const handleLineSpacingChange = (data) => {
        dispatch(setLineSpacing(data));
      }
    
      const handleAlignmentChange = (data) => {
        dispatch(setAlign(data));
      }
    
      const handleLayoutChange = (data) => {
        dispatch(setLayout(data));
      }
    
      const fonttypekRadioButtonFields = [
        { label: 'Sans-serif', value: 'sans-serif' },
        { label: 'Serif', value: 'serif' },
      ];
      
      const handleClick = () => {
        console.info('You clicked the Chip.');
      };

    const handleOpenNavMenu = (event) => {
        setAnchorElNav(event.currentTarget);
    };

    const handleCloseNavMenu = () => {
        setAnchorElNav(null);
    };



    return (
        <>
            <CssBaseline />
            <ElevationScroll {...props}>
                <AppBar position="fixed" sx={{ backgroundColor: 'white'}}>
                    <Container maxWidth="xl" >
                        <Toolbar disableGutters>
                            {/* back button */}
                            <Stack spacing={.5} direction="row" alignItems={'center'}>
                                <IconButton edge="start" color="inherit" aria-label="backArrow" sx={{ mr: 2 }} onClick={handleBackButtonClick}>
                                    <ArrowBackIosNewRounded className={styles.logoColor} />
                                </IconButton>
                                <Typography variant="h6" component='div' className={styles.backText} >
                                    Back
                                </Typography>
                            </Stack>

                            <Box sx={{ flexGrow: 1, display: { xs: 'flex', md: 'none' }, justifyContent:'flex-end'}}>
                                <IconButton
                                    size="large"
                                    aria-label="account of current user"
                                    aria-controls="menu-appbar"
                                    aria-haspopup="true"
                                    onClick={handleOpenNavMenu}
                                    color="red"
                                >
                                    <MenuIcon sx={Boolean(anchorElNav)? {color:'#735BF2', boxSizing:1, borderRadius: '4px', backgroundColor:'#E8DEF9'} : {color:'#735BF2'}}/>
                                </IconButton>
                                <Menu
                                    id="menu-appbar"
                                    // anchorEl={anchorElNav}
                                    anchorOrigin={{
                                        vertical: 'top',
                                        horizontal: 'right',
                                    }}
                                    keepMounted
                                    transformOrigin={{
                                        vertical: 'top',
                                        horizontal: 'right',
                                    }}
                                    open={Boolean(anchorElNav)}
                                    onClose={handleCloseNavMenu}
                                    sx={{
                                        display: { xs: 'block', md: 'none', top: '30px'} ,
                                    }}
                                >
                                    <Stack spacing={.5} direction="column" sx={{ margin: '6px', justifyContent: 'center' }}>
                                        <NumberInput min={8} max={96} value={fontSize} changeHandler={handleFontSizeChange} /> 
                                        <Typography variant="h6" component='div' className={styles.HeaderLabel}>Font size</Typography>
                                    </Stack>
                                    <Stack spacing={.5} direction="column" sx={{ margin: '6px', justifyContent: 'center' }}>
                                        <Stack spacing={.5} direction="row" sx={{marginTop:'4px'}}>
                                            <CustomRadioChip
                                                handleClick = {setFonttype}
                                                selected = {fonts}
                                                fields = {fonttypekRadioButtonFields}
                                                additionalStyles={{height:'3rem'}}
                                            />
                                        </Stack>
                                        <Typography variant="h6" component='div' className={styles.HeaderLabel}>Font type</Typography>
                                    </Stack>
                                    <Stack spacing={.5} direction="column" sx={{ margin: '6px', alignItems: 'center' }}>
                                        <Stack spacing={1} direction="row" sx={{alignItems: 'center'}}>
                                            < Image
                                                src="/images/format_letter_spacing_wider.png"
                                                width={0}
                                                height={0}
                                                sizes="100vw"
                                                style={{ width: '28px', height: '30px' }} // optional
                                            />
                                            <CustomTextInputForNumber type="float" min={.01} max={10} value={lineSpacing} changeHandler={handleLineSpacingChange} />
                                        </Stack>
                                        <Typography variant="h6" component='div' className={styles.HeaderLabel}>Letter spacing</Typography>
                                    </Stack>
                                    <Stack spacing={.5} direction="column" sx={{ margin: '6px', alignItems:'center' }}>
                                        <Stack spacing={1} direction="row" sx={{ alignItems:'center'}}>
                                            < Image
                                                src="/images/letter_height.png"
                                                width={0}
                                                height={0}
                                                sizes="100vw"
                                                style={{ width: '28px', height: '30px' }} // optional
                                            />
                                            <CustomTextInputForNumber type="float" min={10} max={50} value={lineHeight} changeHandler={handleLineHeightChange} />
                                        </Stack>
                                        <Typography variant="h6" component='div' className={styles.HeaderLabel}>Line height</Typography>
                                    </Stack>
                                    <Stack spacing={.5} direction="column" sx={{ margin: '6px', justifyContent: 'center' }}>
                                        <Stack spacing={1} direction="row" sx={{justifyContent:'center'}}>
                                            < AlignmentToggle defaultValue={layout} handleChange={handleLayoutChange}>
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
                                    <Stack spacing={.5} direction="column" sx={{ margin: '6px', justifyContent: 'center' }}>
                                        <Stack spacing={1} direction="row" sx={{justifyContent:'center'}}>
                                            < AlignmentToggle defaultValue={alignment} handleChange={handleAlignmentChange}>
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
                                </Menu>
                            </Box>
                            {/* big size scree menu */}
                            <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'flex' }, justifyContent: 'center', backgroundColor: 'white', border: '0px', borderColor: 'white' }}>
                                <Box sx={{ flexGrow: 0, display: { xs: 'none', md: 'flex' }, backgroundColor: 'white', border: '1px solid hsl(0, 1%, 79%)', borderRadius: '4px', margin: '4px', justifyContent: 'space-around' }}>
                                    <Stack spacing={.5} direction="column" sx={{ margin: '6px', justifyContent: 'center' }}>
                                        {/* <Stack spacing={2} direction="row"> */}
                                        <NumberInput min={8} max={96} value={fontSize} changeHandler={handleFontSizeChange} /> 
                                        {/* </Stack> */}
                                        <Typography variant="h6" component='div' className={styles.HeaderLabel}>Font size</Typography>
                                    </Stack>
                                    <Stack spacing={.5} direction="column" sx={{ margin: '6px', justifyContent: 'center' }}>
                                        <Stack spacing={.5} direction="row" sx={{marginTop:'4px'}}>
                                            <CustomRadioChip
                                                handleClick = {setFonttype}
                                                selected = {fonts}
                                                fields = {fonttypekRadioButtonFields}
                                                additionalStyles={{height:'3rem'}}
                                            />
                                        </Stack>
                                        <Typography variant="h6" component='div' className={styles.HeaderLabel}>Font type</Typography>
                                    </Stack>
                                    <Stack spacing={.5} direction="column" sx={{ margin: '6px', alignItems: 'center' }}>
                                        <Stack spacing={1} direction="row" alignItems={'center'}>
                                            < Image
                                                src="/images/format_letter_spacing_wider.png"
                                                width={0}
                                                height={0}
                                                sizes="100vw"
                                                style={{ width: '28px', height: '30px' }} // optional
                                            />
                                            <CustomTextInputForNumber type="float" min={.01} max={10} value={lineSpacing} changeHandler={handleLineSpacingChange} />
                                        </Stack>
                                        <Typography variant="h6" component='div' className={styles.HeaderLabel}>Letter spacing</Typography>
                                    </Stack>
                                    <Stack spacing={.5} direction="column" sx={{ margin: '6px', alignItems: 'center' }}>
                                        <Stack spacing={1} direction="row" alignItems={'center'}>
                                            < Image
                                                src="/images/letter_height.png"
                                                width={0}
                                                height={0}
                                                sizes="100vw"
                                                style={{ width: '28px', height: '30px' }} // optional
                                            />
                                            <CustomTextInputForNumber type="float" min={10} max={50} value={lineHeight} changeHandler={handleLineHeightChange} />
                                        </Stack>
                                        <Typography variant="h6" component='div' className={styles.HeaderLabel}>Line height</Typography>
                                    </Stack>
                                    <Stack spacing={.5} direction="column" sx={{ margin: '6px', justifyContent: 'center' }}>
                                        <Stack spacing={1} direction="row" alignItems={'center'}>
                                            < AlignmentToggle defaultValue={layout} handleChange={handleLayoutChange}>
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
                                    <Stack spacing={.5} direction="column" sx={{ margin: '6px', justifyContent: 'center' }}>
                                        <Stack spacing={1} direction="row" alignItems={'center'}>
                                            < AlignmentToggle defaultValue={alignment} handleChange={handleAlignmentChange}>
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
                                </Box>
                            </Box>
                        </Toolbar>
                    </Container>
                </AppBar>
            </ElevationScroll>
            <Toolbar />
            {/* <Container> */}
                {/* <Box sx={{ my: 2 }}> */}
                    {props.children}
                {/* </Box> */}
            {/* </Container> */}
        </>
    );
}
export default ResponsiveLayout;
