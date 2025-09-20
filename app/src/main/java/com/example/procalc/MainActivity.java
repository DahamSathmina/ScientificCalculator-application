package com.example.procalc;

import android.animation.ObjectAnimator;
import android.content.res.Configuration;
import android.media.AudioManager;
import android.media.ToneGenerator;
import android.os.Bundle;
import android.view.View;
import android.view.animation.DecelerateInterpolator;
import android.widget.Button;
import android.widget.TextView;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.app.AppCompatDelegate;
import java.text.DecimalFormat;

/**
 * ProCalc - iOS-style Calculator for Android
 * Main activity that handles all calculator operations and UI interactions
 */
public class MainActivity extends AppCompatActivity implements View.OnClickListener {

    // UI Components
    private TextView displayTextView;
    private TextView operationTextView;
    
    // Calculator state variables
    private double operand1 = 0;
    private double operand2 = 0;
    private String operator = "";
    private boolean isNewNumber = true;
    private boolean hasDecimal = false;
    private boolean isOperatorPressed = false;
    private String lastOperation = "";
    
    // Memory functions
    private double memoryValue = 0;
    
    // Sound generator for button clicks
    private ToneGenerator toneGenerator;
    
    // Number formatter
    private DecimalFormat decimalFormat;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        
        // Set theme based on system preference
        int currentNightMode = getResources().getConfiguration().uiMode & Configuration.UI_MODE_NIGHT_MASK;
        switch (currentNightMode) {
            case Configuration.UI_MODE_NIGHT_NO:
                AppCompatDelegate.setDefaultNightMode(AppCompatDelegate.MODE_NIGHT_NO);
                break;
            case Configuration.UI_MODE_NIGHT_YES:
                AppCompatDelegate.setDefaultNightMode(AppCompatDelegate.MODE_NIGHT_YES);
                break;
        }
        
        setContentView(R.layout.activity_main);
        
        initializeViews();
        initializeCalculator();
    }

    /**
     * Initialize all UI components and set click listeners
     */
    private void initializeViews() {
        displayTextView = findViewById(R.id.displayTextView);
        operationTextView = findViewById(R.id.operationTextView);
        
        // Number buttons
        findViewById(R.id.btn0).setOnClickListener(this);
        findViewById(R.id.btn1).setOnClickListener(this);
        findViewById(R.id.btn2).setOnClickListener(this);
        findViewById(R.id.btn3).setOnClickListener(this);
        findViewById(R.id.btn4).setOnClickListener(this);
        findViewById(R.id.btn5).setOnClickListener(this);
        findViewById(R.id.btn6).setOnClickListener(this);
        findViewById(R.id.btn7).setOnClickListener(this);
        findViewById(R.id.btn8).setOnClickListener(this);
        findViewById(R.id.btn9).setOnClickListener(this);
        
        // Operation buttons
        findViewById(R.id.btnAdd).setOnClickListener(this);
        findViewById(R.id.btnSubtract).setOnClickListener(this);
        findViewById(R.id.btnMultiply).setOnClickListener(this);
        findViewById(R.id.btnDivide).setOnClickListener(this);
        findViewById(R.id.btnEquals).setOnClickListener(this);
        
        // Special buttons
        findViewById(R.id.btnClear).setOnClickListener(this);
        findViewById(R.id.btnDecimal).setOnClickListener(this);
        findViewById(R.id.btnPlusMinus).setOnClickListener(this);
        findViewById(R.id.btnPercent).setOnClickListener(this);
        
        // Advanced functions
        findViewById(R.id.btnSqrt).setOnClickListener(this);
        findViewById(R.id.btnReciprocal).setOnClickListener(this);
        
        // Memory functions
        findViewById(R.id.btnMC).setOnClickListener(this);
        findViewById(R.id.btnMR).setOnClickListener(this);
        findViewById(R.id.btnMPlus).setOnClickListener(this);
        findViewById(R.id.btnMMinus).setOnClickListener(this);
    }

    /**
     * Initialize calculator settings and formatting
     */
    private void initializeCalculator() {
        // Initialize tone generator for button sounds
        toneGenerator = new ToneGenerator(AudioManager.STREAM_DTMF, 50);
        
        // Initialize decimal formatter
        decimalFormat = new DecimalFormat("#.##########");
        decimalFormat.setMaximumFractionDigits(10);
        
        // Set initial display
        displayTextView.setText("0");
        operationTextView.setText("");
    }

    @Override
    public void onClick(View view) {
        // Play button click sound
        playClickSound();
        
        // Add button press animation
        animateButton(view);
        
        // Handle button click based on ID
        int id = view.getId();
        
        if (id == R.id.btn0 || id == R.id.btn1 || id == R.id.btn2 || id == R.id.btn3 || 
            id == R.id.btn4 || id == R.id.btn5 || id == R.id.btn6 || id == R.id.btn7 || 
            id == R.id.btn8 || id == R.id.btn9) {
            handleNumberClick(view);
        } else if (id == R.id.btnAdd || id == R.id.btnSubtract || id == R.id.btnMultiply || id == R.id.btnDivide) {
            handleOperatorClick(view);
        } else if (id == R.id.btnEquals) {
            handleEqualsClick();
        } else if (id == R.id.btnClear) {
            handleClearClick();
        } else if (id == R.id.btnDecimal) {
            handleDecimalClick();
        } else if (id == R.id.btnPlusMinus) {
            handlePlusMinusClick();
        } else if (id == R.id.btnPercent) {
            handlePercentClick();
        } else if (id == R.id.btnSqrt) {
            handleSqrtClick();
        } else if (id == R.id.btnReciprocal) {
            handleReciprocalClick();
        } else if (id == R.id.btnMC) {
            handleMemoryClear();
        } else if (id == R.id.btnMR) {
            handleMemoryRecall();
        } else if (id == R.id.btnMPlus) {
            handleMemoryPlus();
        } else if (id == R.id.btnMMinus) {
            handleMemoryMinus();
        }
    }

    /**
     * Handle number button clicks
     */
    private void handleNumberClick(View view) {
        Button button = (Button) view;
        String number = button.getText().toString();
        String currentDisplay = displayTextView.getText().toString();
        
        if (isNewNumber) {
            displayTextView.setText(number);
            isNewNumber = false;
            hasDecimal = false;
        } else {
            if (currentDisplay.equals("0")) {
                displayTextView.setText(number);
            } else {
                displayTextView.setText(currentDisplay + number);
            }
        }
        isOperatorPressed = false;
    }

    /**
     * Handle operator button clicks (+, -, ×, ÷)
     */
    private void handleOperatorClick(View view) {
        Button button = (Button) view;
        String newOperator = button.getText().toString();
        
        if (!isOperatorPressed && !operator.isEmpty()) {
            // Perform calculation if there's a pending operation
            operand2 = Double.parseDouble(displayTextView.getText().toString());
            double result = performCalculation();
            displayTextView.setText(formatResult(result));
            operand1 = result;
        } else {
            operand1 = Double.parseDouble(displayTextView.getText().toString());
        }
        
        operator = newOperator;
        updateOperationDisplay();
        isNewNumber = true;
        isOperatorPressed = true;
    }

    /**
     * Handle equals button click
     */
    private void handleEqualsClick() {
        if (!operator.isEmpty() && !isOperatorPressed) {
            operand2 = Double.parseDouble(displayTextView.getText().toString());
            double result = performCalculation();
            displayTextView.setText(formatResult(result));
            
            lastOperation = operand1 + " " + operator + " " + operand2 + " = " + formatResult(result);
            operationTextView.setText("");
            
            operand1 = result;
            operator = "";
            isNewNumber = true;
        }
    }

    /**
     * Handle clear button click (C/AC functionality)
     */
    private void handleClearClick() {
        Button clearButton = findViewById(R.id.btnClear);
        
        if (displayTextView.getText().toString().equals("0") && operator.isEmpty()) {
            // All Clear - reset everything
            operand1 = 0;
            operand2 = 0;
            operator = "";
            operationTextView.setText("");
            clearButton.setText("AC");
        } else {
            // Clear current input
            displayTextView.setText("0");
            if (operator.isEmpty()) {
                operand1 = 0;
                operationTextView.setText("");
            }
        }
        
        isNewNumber = true;
        hasDecimal = false;
        isOperatorPressed = false;
        
        // Update button text
        clearButton.setText(displayTextView.getText().toString().equals("0") && operator.isEmpty() ? "AC" : "C");
    }

    /**
     * Handle decimal point click
     */
    private void handleDecimalClick() {
        String currentDisplay = displayTextView.getText().toString();
        
        if (isNewNumber) {
            displayTextView.setText("0.");
            isNewNumber = false;
            hasDecimal = true;
        } else if (!hasDecimal) {
            displayTextView.setText(currentDisplay + ".");
            hasDecimal = true;
        }
        isOperatorPressed = false;
    }

    /**
     * Handle plus/minus toggle
     */
    private void handlePlusMinusClick() {
        String currentDisplay = displayTextView.getText().toString();
        double value = Double.parseDouble(currentDisplay);
        value = -value;
        displayTextView.setText(formatResult(value));
    }

    /**
     * Handle percentage calculation
     */
    private void handlePercentClick() {
        double value = Double.parseDouble(displayTextView.getText().toString());
        value = value / 100;
        displayTextView.setText(formatResult(value));
        isNewNumber = true;
    }

    /**
     * Handle square root calculation
     */
    private void handleSqrtClick() {
        double value = Double.parseDouble(displayTextView.getText().toString());
        if (value < 0) {
            displayTextView.setText("Error");
        } else {
            value = Math.sqrt(value);
            displayTextView.setText(formatResult(value));
        }
        isNewNumber = true;
    }

    /**
     * Handle reciprocal calculation (1/x)
     */
    private void handleReciprocalClick() {
        double value = Double.parseDouble(displayTextView.getText().toString());
        if (value == 0) {
            displayTextView.setText("Error");
        } else {
            value = 1 / value;
            displayTextView.setText(formatResult(value));
        }
        isNewNumber = true;
    }

    /**
     * Memory Clear function
     */
    private void handleMemoryClear() {
        memoryValue = 0;
    }

    /**
     * Memory Recall function
     */
    private void handleMemoryRecall() {
        displayTextView.setText(formatResult(memoryValue));
        isNewNumber = true;
    }

    /**
     * Memory Plus function
     */
    private void handleMemoryPlus() {
        double currentValue = Double.parseDouble(displayTextView.getText().toString());
        memoryValue += currentValue;
    }

    /**
     * Memory Minus function
     */
    private void handleMemoryMinus() {
        double currentValue = Double.parseDouble(displayTextView.getText().toString());
        memoryValue -= currentValue;
    }

    /**
     * Perform the actual calculation based on the operator
     */
    private double performCalculation() {
        double result = 0;
        
        switch (operator) {
            case "+":
                result = operand1 + operand2;
                break;
            case "−":
                result = operand1 - operand2;
                break;
            case "×":
                result = operand1 * operand2;
                break;
            case "÷":
                if (operand2 == 0) {
                    displayTextView.setText("Error");
                    return 0;
                }
                result = operand1 / operand2;
                break;
            default:
                result = operand2;
        }
        
        return result;
    }

    /**
     * Format the result for display
     */
    private String formatResult(double result) {
        if (Double.isInfinite(result) || Double.isNaN(result)) {
            return "Error";
        }
        
        // Remove unnecessary decimal places
        if (result == (long) result) {
            return String.valueOf((long) result);
        } else {
            return decimalFormat.format(result);
        }
    }

    /**
     * Update the operation display
     */
    private void updateOperationDisplay() {
        String operationText = formatResult(operand1) + " " + operator;
        operationTextView.setText(operationText);
        
        // Update clear button text
        Button clearButton = findViewById(R.id.btnClear);
        clearButton.setText("C");
    }

    /**
     * Play button click sound
     */
    private void playClickSound() {
        if (toneGenerator != null) {
            toneGenerator.startTone(ToneGenerator.TONE_DTMF_1, 50);
        }
    }

    /**
     * Animate button press
     */
    private void animateButton(View view) {
        ObjectAnimator scaleDown = ObjectAnimator.ofFloat(view, "scaleX", 1.0f, 0.95f);
        scaleDown.setDuration(50);
        scaleDown.setInterpolator(new DecelerateInterpolator());
        
        ObjectAnimator scaleUp = ObjectAnimator.ofFloat(view, "scaleX", 0.95f, 1.0f);
        scaleUp.setDuration(50);
        scaleUp.setStartDelay(50);
        scaleUp.setInterpolator(new DecelerateInterpolator());
        
        ObjectAnimator scaleDownY = ObjectAnimator.ofFloat(view, "scaleY", 1.0f, 0.95f);
        scaleDownY.setDuration(50);
        scaleDownY.setInterpolator(new DecelerateInterpolator());
        
        ObjectAnimator scaleUpY = ObjectAnimator.ofFloat(view, "scaleY", 0.95f, 1.0f);
        scaleUpY.setDuration(50);
        scaleUpY.setStartDelay(50);
        scaleUpY.setInterpolator(new DecelerateInterpolator());
        
        scaleDown.start();
        scaleUp.start();
        scaleDownY.start();
        scaleUpY.start();
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        if (toneGenerator != null) {
            toneGenerator.release();
        }
    }
}